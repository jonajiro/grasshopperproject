#include <M5StickC.h>
#include "BluetoothSerial.h"
#include <Ticker.h>
#include <Wire.h>
#include <MadgwickAHRS.h>
#include <PCA9685.h>            //PCA9685用ヘッダーファイル（秋月電子通商作成）

#define M_PI 3.1415927
#define M_GR 9.80665
#define M_R 0.0034837
#define M_T 273.15
#define M_P0 1013.25

//FlexPWM1.3  7, 8, 25  4.482 kHz
#define S_limbA 0     //エレボン左
#define S_limbB 1     //エレボン右
#define S_limbC 2     //エレボン右

#define SERVOMIN 150            //最小パルス幅 (標準的なサーボパルスに設定)
#define SERVOMAX 500            //最大パルス幅 (標準的なサーボパルスに設定)

#define Si1buf_size 256
#define Si1readbyte_len 39

BluetoothSerial SerialBT;
Madgwick filter;
PCA9685 pwm = PCA9685(0x40);    //PCA9685のアドレス指定（アドレスジャンパ未接続時）
Ticker ticker_timer;

byte Serial1_buffer[Si1buf_size];
int Serial1_buffer_len = 0;

unsigned long cnt0 = 0;//時間カウンタ
int cnt1 = 0;//LEDカウンタ
int cnt2 = 0;//データ送信カウンタ
int cnt3 = 0;//制御カウンタ
int cnt4 = 0;//計測カウンタ
int control_state1 = 0;
int control_state2 = 0;
float t = 0.0;
unsigned long time_u = 0;
unsigned long pretime_u = 0;
float dt = 0.001;//s
boolean cnt1_flag = HIGH;
boolean cnt2_flag = LOW;
boolean cnt3_flag = LOW;
boolean cnt4_flag = LOW;
float delay_tau = 0.0;//計測制定待ち時間[ms]
float cnt1_time = 1.0;//割り込み周期[sec]//LEDカウンタ
float cnt2_time = 0.02;//割り込み周期[sec]//データ送信カウンタ
float cnt3_time = 0.02;//割り込み周期[sec]//制御カウンタ
float cnt4_time = 0.02;//割り込み周期[sec]//計測カウンタ
double con_time = 0.0;

int statuspc = 0;
float pc_t = 0.0;
float limb_angle[16];

int statusmpu = 0;
float reg_data[16];

float acc_data[3] = {0, 0, 0}; //[m/s^2]
float gyro_data[3] = {0, 0, 0}; //[rad/s]
float euler_data[3] = {0, 0, 0}; //[rad]
float angvel_data[3] = {0, 0, 0}; //[rad/s]
float angvel_data_f[3] = {0, 0, 0}; //[rad/s]

float gyro_offset_data[3] = {0, 0, 0};
float acc_offset_data[3] = {0, 0, 0};

float imu_factor = 1.0;
float acc_roll = 0.0;
float acc_pitch = 0.0;

float lpf_ca = 0.0;
float lpf_cg = 0.0;
float lpf_data_f[6] = {0, 0, 0, 0, 0, 0};

//プロトタイプ宣言
void D_L(void);
void C_L(void);
void W_L(void);
void R_L(void);

void my_setup(void);
void IntervalSet(float interupt_time);
void data_init(void);
void servo_init(void);
void servo_rotation(int ch, float ang);

void sensor_init(void);
void Gyro_init(void);

void get_mpu6886(void);
void get_mpu6886_nonfilter(void);

void calc_attitude(void);
void calc_attitude_Madgwick(void);

void control_init(void);
