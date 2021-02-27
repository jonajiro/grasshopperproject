#include "init.h"

void setup() {
  my_setup();
}

void loop() {
  D_L();
  C_L();
  W_L();
  R_L();
}

void timer_1() {//
  t = t + dt;
  cnt0 = cnt0 + 1;
  cnt1 = cnt1 + 1;
  cnt2 = cnt2 + 1;
  cnt3 = cnt3 + 1;
  cnt4 = cnt4 + 1;
  // Serial.println(t);
  if (cnt1 > (int)(cnt1_time / dt) - 1) { //led function
    cnt1_flag = !cnt1_flag;
    cnt1 = 0;
  }
  if (cnt2 > (int)(cnt2_time / dt) - 1) { //send data flag
    cnt2_flag = HIGH;
    cnt2 = 0;
  }
  if (cnt3 > (int)(cnt3_time / dt) - 1) { //control flag
    cnt3_flag = HIGH;
    cnt3 = 0;
  }
  if (cnt4 > (int)(cnt4_time / dt) - 1) { //check power flag
    cnt4_flag = HIGH;
    cnt4 = 0;
  }
}

void W_L() { //データ送信する関数
  if (cnt2_flag) {
    int i = 0;
    byte s_uchMsg[52];
    word ushTmp;
    //start byte
    s_uchMsg[0] = 0xa5;
    s_uchMsg[1] = 0x5a;

    //statusmpu
    ushTmp = (byte)(statusmpu);
    s_uchMsg[2] = ushTmp;

    //mpu_t
    ushTmp = (word)(t / 600.0 * 65535.0);
    s_uchMsg[3] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[4] = (byte)(ushTmp & 0x00ff);

    //acc_data
    ushTmp = (word)((reg_data[0] + 16.0) / (32.0) * 65535.0);
    s_uchMsg[5] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[6] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[1] + 16.0) / (32.0) * 65535.0);
    s_uchMsg[7] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[8] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[2] + 16.0) / (32.0) * 65535.0);
    s_uchMsg[9] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[10] = (byte)(ushTmp & 0x00ff);

    //gyro_data
    ushTmp = (word)((reg_data[3] + 3 * M_PI) / (6 * M_PI) * 65535.0);
    s_uchMsg[11] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[12] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[4] + 3 * M_PI) / (6 * M_PI) * 65535.0);
    s_uchMsg[13] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[14] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[5] + 3 *  M_PI) /  (6 * M_PI) * 65535.0);
    s_uchMsg[15] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[16] = (byte)(ushTmp & 0x00ff);

    //euler_data
    ushTmp = (word)((reg_data[6] + M_PI) /  (2 * M_PI) * 65535.0);
    s_uchMsg[17] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[18] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[7] + M_PI) /  (2 * M_PI) * 65535.0);
    s_uchMsg[19] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[20] = (byte)(ushTmp & 0x00ff);

    ushTmp = (word)((reg_data[8] + M_PI) /  (2 * M_PI) * 65535.0);
    s_uchMsg[21] = (byte)(ushTmp >> 8 & 0x00ff);
    s_uchMsg[22] = (byte)(ushTmp & 0x00ff);

    //end byte
    s_uchMsg[23] = 0x0d;
    s_uchMsg[24] = 0x0a;

    SerialBT.write(s_uchMsg, sizeof(s_uchMsg));
    cnt2_flag = LOW;
  }
}


void C_L() { //制御関数
  if (cnt3_flag) {
    servo_rotation(0, limb_angle[0] * 180.0 / M_PI);
    servo_rotation(1, limb_angle[1] * 180.0 / M_PI);
    servo_rotation(2, limb_angle[2] * 180.0 / M_PI);

    servo_rotation(4, limb_angle[4] * 180.0 / M_PI);
    servo_rotation(5, limb_angle[5] * 180.0 / M_PI);
    servo_rotation(6, limb_angle[6] * 180.0 / M_PI);

    servo_rotation(8, limb_angle[8] * 180.0 / M_PI);
    servo_rotation(9, limb_angle[9] * 180.0 / M_PI);
    servo_rotation(10, limb_angle[10] * 180.0 / M_PI);

    servo_rotation(12, limb_angle[12] * 180.0 / M_PI);
    servo_rotation(13, limb_angle[13] * 180.0 / M_PI);
    servo_rotation(14, limb_angle[14] * 180.0 / M_PI);
    statusmpu = 1;
    cnt3_flag = LOW;
  }
}

void D_L() { //計測する関数

  pretime_u = time_u;
  time_u = micros();
  if (cnt4_flag) {
    get_mpu6886();
    reg_data[0] = acc_data[0];
    reg_data[1] = acc_data[1];
    reg_data[2] = acc_data[2];

    reg_data[3] = gyro_data[0];
    reg_data[4] = gyro_data[1];
    reg_data[5] = gyro_data[2];

    reg_data[6] = euler_data[0];
    reg_data[7] = euler_data[1];
    reg_data[8] = euler_data[2];
    //    Serial.printf("%5.1f, %5.1f, %5.1f\r\n", euler_data[0],euler_data[1],euler_data[2]);
    cnt4_flag = LOW;
  }
}


void R_L() {
  float get_data[16];
  int i = 0;
  int tmp_len = 0;
  byte Serial1_buffer_tmp[Si1buf_size];
  for (i = 0; i < Si1buf_size; i++) {
    Serial1_buffer_tmp[i] = 0x00;
  }

  //シリアル情報取得
  while ( SerialBT.available()) {
    if (tmp_len >= Si1buf_size)break;
    Serial1_buffer_tmp[tmp_len] = SerialBT.read();
    tmp_len = tmp_len + 1;
  }

  //バッファに貯める
  if (tmp_len > (Si1buf_size - Serial1_buffer_len)) {
    //バッファサイズからはみ出るとき、はみ出た分削除の後、取得分追加
    //    Serial.println("バッファサイズからはみ出るとき、はみ出た分削除の後、取得分追加");
    int over_len = 0;
    over_len = tmp_len - (Si1buf_size - Serial1_buffer_len);
    byte swp_sil1_buf[Si1buf_size];
    for (i = 0; i < Si1buf_size; i++) {
      swp_sil1_buf[i] = Serial1_buffer[i];
    }
    for (i = 0; i < Si1buf_size - over_len; i++) {
      Serial1_buffer[i] = swp_sil1_buf[i + over_len];
    }
    Serial1_buffer_len = Serial1_buffer_len - over_len;
    for (i = 0; i < tmp_len; i++) {
      Serial1_buffer[Serial1_buffer_len + i] = Serial1_buffer_tmp[i];
    }
    Serial1_buffer_len = Serial1_buffer_len + tmp_len;
    //    Serial.println(Serial1_buffer_len);
  } else {
    //バッファサイズからはみ出ないとき、取得分追加
    //    Serial.println("バッファサイズからはみ出ないとき、取得分追加");
    for (i = 0; i < tmp_len; i++) {
      Serial1_buffer[Serial1_buffer_len + i] = Serial1_buffer_tmp[i];
    }
    Serial1_buffer_len = Serial1_buffer_len + tmp_len;
    //    Serial.println(Serial1_buffer_len);
  }
  //データ読み出し

  for (int i = 0; i < Serial1_buffer_len - Si1readbyte_len; i++) {
    int buf_len = 0;

    if ( Serial1_buffer[i + buf_len] == 0xa5 ) {
      buf_len = buf_len + 1;
      if ( Serial1_buffer[i + buf_len] == 0x5a ) {
        buf_len = buf_len + 1;
        int n = 0;
        word ushTmp;
        byte low;
        byte high;
        //statuspc
        statuspc = (int)Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;

        //pc_t
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        pc_t = ((double)ushTmp / 65535.0 * 600.0);

        //limb1
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[0] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb2
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[1] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb3
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[2] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb4
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[3] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb5
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[4] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb6
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[5] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb7
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[6] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb8
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[7] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb9
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[8] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb10
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[9] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb11
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[10] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb12
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[11] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb13
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[12] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb14
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[13] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb15
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[14] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        //limb16
        low = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        high = Serial1_buffer[i + buf_len];
        buf_len = buf_len + 1;
        ushTmp = (word)(((low << 8) & 0xff00) | (high & 0x00ff));
        get_data[15] = ((double)ushTmp / 65535.0 * 2.0 * M_PI - 0.0);

        if ( Serial1_buffer[i + buf_len] == 0x0d ) {
          buf_len = buf_len + 1;
          if ( Serial1_buffer[i + buf_len] == 0x0a ) {
            buf_len = buf_len + 1;
            //パケット取得成功のため、取得分より前データ削除
            int over_len = i + buf_len;
            byte swp_sil1_buf[Si1buf_size];
            for (int i = 0; i < Si1buf_size; i++)swp_sil1_buf[i] = Serial1_buffer[i];
            for (int i = 0; i < Si1buf_size - over_len; i++)Serial1_buffer[i] = swp_sil1_buf[i + over_len];
            Serial1_buffer_len = Serial1_buffer_len - over_len;

            limb_angle[0] = get_data[0];
            limb_angle[1] = get_data[1];
            limb_angle[2] = get_data[2];
            limb_angle[3] = get_data[3];

            limb_angle[4] = get_data[4];
            limb_angle[5] = get_data[5];
            limb_angle[6] = get_data[6];
            limb_angle[7] = get_data[7];

            limb_angle[8] = get_data[8];
            limb_angle[9] = get_data[9];
            limb_angle[10] = get_data[10];
            limb_angle[11] = get_data[11];

            limb_angle[12] = get_data[12];
            limb_angle[13] = get_data[13];
            limb_angle[14] = get_data[14];
            limb_angle[15] = get_data[15];
            Serial.println(limb_angle[0]);
          }
        }
      }
    }
  }

}
