void sensor_init(void) {
  M5.MPU6886.Init();
  Gyro_init();
}

void Gyro_init(void) {
  float gyroX, gyroY, gyroZ;  // ジャイロデータ取得　→回転(左90 0/-50/0, 右90 0/50/0)
  float accX, accY, accZ;  // 加速度データ取得　→傾き(X/Y/Z: 正 0/0/1, 左90 1/0/0, 右90 -1/0/0, 上90 0/-1/0, 下90 0/1/0)
  float pitch, roll, yaw;
  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  M5.MPU6886.getAhrsData(&pitch, &roll, &yaw);
  acc_data[0] = accX;
  acc_data[1] = accY;
  acc_data[2] = accZ;

  gyro_data[0] = gyroX;
  gyro_data[1] = gyroY;
  gyro_data[2] = gyroZ;

  euler_data[0] = roll * M_PI / 180.0;
  euler_data[1] = pitch * M_PI / 180.0;
  euler_data[2] = yaw * M_PI / 180.0;

  int i = 0;
  float gyro_initdata[3] = {0, 0, 0};
  float acc_initdata[3] = {0, 0, 0};

  for (i = 0; i < 1000; i++) {
    delay(1);
    get_mpu6886_nonfilter();
    acc_initdata[0] = acc_initdata[0] + acc_data[0];
    acc_initdata[1] = acc_initdata[1] + acc_data[1];
    acc_initdata[2] = acc_initdata[2] + acc_data[2];

    gyro_initdata[0] = gyro_initdata[0] + gyro_data[0];
    gyro_initdata[1] = gyro_initdata[1] + gyro_data[1];
    gyro_initdata[2] = gyro_initdata[2] + gyro_data[2];

  }
  acc_offset_data[0] = -acc_initdata[0] / 1000.0;
  acc_offset_data[1] = -acc_initdata[1] / 1000.0;
  acc_offset_data[2] = -acc_initdata[2] / 1000.0;

  gyro_offset_data[0] = -gyro_initdata[0] / 1000.0;
  gyro_offset_data[1] = -gyro_initdata[1] / 1000.0;
  gyro_offset_data[2] = -gyro_initdata[2] / 1000.0;
}

void get_mpu6886(void) {
  float gyroX, gyroY, gyroZ;  // ジャイロデータ取得　→回転(左90 0/-50/0, 右90 0/50/0)
  float accX, accY, accZ;  // 加速度データ取得　→傾き(X/Y/Z: 正 0/0/1, 左90 1/0/0, 右90 -1/0/0, 上90 0/-1/0, 下90 0/1/0)
  float pitch, roll, yaw;
  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  M5.MPU6886.getAhrsData(&pitch, &roll, &yaw);
  acc_data[0] = lpf_ca * lpf_data_f[0] - (1.0 - lpf_ca) * (float)accX / 16384.0 * M_GR + acc_offset_data[0];
  acc_data[1] = lpf_ca * lpf_data_f[1] - (1.0 - lpf_ca) * (float)accY / 16384.0 * M_GR + acc_offset_data[1];
  acc_data[2] = lpf_ca * lpf_data_f[2] - (1.0 - lpf_ca) * (float)accZ / 16384.0 * M_GR + acc_offset_data[2];

  gyro_data[0] = lpf_cg * lpf_data_f[3] + (1.0 - lpf_cg) * ((float)gyroX / 131.0 / 180.0 * M_PI + gyro_offset_data[0]);
  gyro_data[1] = lpf_cg * lpf_data_f[4] + (1.0 - lpf_cg) * ((float)gyroY / 131.0 / 180.0 * M_PI + gyro_offset_data[1]);
  gyro_data[2] = lpf_cg * lpf_data_f[5] + (1.0 - lpf_cg) * ((float)gyroZ / 131.0 / 180.0 * M_PI + gyro_offset_data[2]);

  euler_data[0] = roll * M_PI / 180.0;
  euler_data[1] = pitch * M_PI / 180.0;
  euler_data[2] = yaw * M_PI / 180.0;

  lpf_data_f[0] = acc_data[0];
  lpf_data_f[1] = acc_data[1];
  lpf_data_f[2] = acc_data[2];
  lpf_data_f[3] = gyro_data[0];
  lpf_data_f[4] = gyro_data[1];
  lpf_data_f[5] = gyro_data[2];
}

void get_mpu6886_nonfilter(void) {
  float gyroX, gyroY, gyroZ;  // ジャイロデータ取得　→回転(左90 0/-50/0, 右90 0/50/0)
  float accX, accY, accZ;  // 加速度データ取得　→傾き(X/Y/Z: 正 0/0/1, 左90 1/0/0, 右90 -1/0/0, 上90 0/-1/0, 下90 0/1/0)
  float pitch, roll, yaw;
  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  M5.MPU6886.getAhrsData(&pitch, &roll, &yaw);
  acc_data[0] = accX;
  acc_data[1] = accY;
  acc_data[2] = accZ;

  gyro_data[0] = gyroX;
  gyro_data[1] = gyroY;
  gyro_data[2] = gyroZ;

  euler_data[0] = roll * M_PI / 180.0;
  euler_data[1] = pitch * M_PI / 180.0;
  euler_data[2] = yaw * M_PI / 180.0;
}
