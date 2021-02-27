void calc_attitude(void) {

  float S_x = sin(gyro_data[0]);
  float C_x = cos(gyro_data[0]);
  float S_y = sin(gyro_data[1]);
  float C_y = cos(gyro_data[1]);
  float S_z = sin(gyro_data[2]);
  float C_z = cos(gyro_data[2]);

  float S_R = sin(euler_data[0]);
  float C_R = cos(euler_data[0]);
  float S_P = sin(euler_data[1]);
  float C_P = cos(euler_data[1]);
  float S_Y = sin(euler_data[2]);
  float C_Y = cos(euler_data[2]);

  if (C_P == 0.0) {
    C_P = 0.0001;//ゼロ割回避
  }
  float cnt4_time_dt = (float)(time_u - pretime_u) / 1000.0 / 1000.0;

  angvel_data[2] = (gyro_data[2] * C_R + gyro_data[1] * S_R) / C_P;
  angvel_data[1] = gyro_data[1] * C_R - gyro_data[2] * S_R;
  angvel_data[0] = gyro_data[0] + angvel_data[2] * S_P;

  float St_angvel_f_data[3];
  St_angvel_f_data[0] = cnt4_time_dt * 0.5 * (angvel_data_f[0] + angvel_data[0]);
  euler_data[0] = euler_data[0] + St_angvel_f_data[0];

  St_angvel_f_data[1] = cnt4_time_dt * 0.5 * (angvel_data_f[1] + angvel_data[1]);
  euler_data[1] = euler_data[1] + St_angvel_f_data[1];

  St_angvel_f_data[2] = cnt4_time_dt * 0.5 * (angvel_data_f[2] + angvel_data[2]);
  euler_data[2] = euler_data[2] + St_angvel_f_data[2];


  float norm_acc = sqrt(acc_data[0] * acc_data[0] + acc_data[1] * acc_data[1] + acc_data[2] * acc_data[2]);
  acc_roll = atan2(acc_data[1], acc_data[2]);

  if (acc_roll < -M_PI) {
    acc_roll = acc_roll + 2 * M_PI;
  }
  if (acc_roll > M_PI) {
    acc_roll = acc_roll - 2 * M_PI;
  }
  acc_pitch = -atan2(acc_data[0], acc_data[2]);

  if (acc_pitch < -M_PI) {
    acc_pitch = acc_pitch + 2 * M_PI;
  }
  if (acc_pitch > M_PI) {
    acc_pitch = acc_pitch - 2 * M_PI;
  }

  float souho_ratio_r = 1;
  float souho_ratio_p = 1;

  euler_data[0] = euler_data[0] * souho_ratio_r + acc_roll * (1.0 - souho_ratio_r);
  euler_data[1] = euler_data[1] * souho_ratio_p + acc_pitch * (1.0 - souho_ratio_p);
  euler_data[2] = euler_data[2];


  if (euler_data[0] < -M_PI) {
    euler_data[0] = euler_data[0] + 2 * M_PI;
  }
  if (euler_data[1] < -M_PI) {
    euler_data[1] = euler_data[1] + 2 * M_PI;
  }
  if (euler_data[2] < -M_PI) {
    euler_data[2] = euler_data[2] + 2 * M_PI;
  }

  if (euler_data[0] > M_PI) {
    euler_data[0] = euler_data[0] - 2 * M_PI;
  }
  if (euler_data[1] > M_PI) {
    euler_data[1] = euler_data[1] - 2 * M_PI;
  }
  if (euler_data[2] > M_PI) {
    euler_data[2] = euler_data[2] - 2 * M_PI;
  }

  angvel_data_f[0] = angvel_data[0];
  angvel_data_f[1] = angvel_data[1];
  angvel_data_f[2] = angvel_data[2];

}

void calc_attitude_Madgwick(void) {

  float S_x = sin(gyro_data[0]);
  float C_x = cos(gyro_data[0]);
  float S_y = sin(gyro_data[1]);
  float C_y = cos(gyro_data[1]);
  float S_z = sin(gyro_data[2]);
  float C_z = cos(gyro_data[2]);

  float S_R = sin(euler_data[0]);
  float C_R = cos(euler_data[0]);
  float S_P = sin(euler_data[1]);
  float C_P = cos(euler_data[1]);
  float S_Y = sin(euler_data[2]);
  float C_Y = cos(euler_data[2]);

  if (C_P == 0.0) {
    C_P = 0.0001;//ゼロ割回避
  }
  float cnt4_time_dt = (float)(time_u - pretime_u) / 1000.0 / 1000.0;

  angvel_data[2] = (gyro_data[2] * C_R + gyro_data[1] * S_R) / C_P;
  angvel_data[1] = gyro_data[1] * C_R - gyro_data[2] * S_R;
  angvel_data[0] = gyro_data[0] + angvel_data[2] * S_P;
  filter.begin(1.0 / cnt4_time_dt);
  filter.updateIMU(gyro_data[0] * 180.0 / M_PI / imu_factor, gyro_data[1] * 180.0 / M_PI / imu_factor, gyro_data[2] * 180.0 / M_PI / imu_factor, acc_data[0] , acc_data[1], acc_data[2]);
  euler_data[0] = filter.getRoll() / 180.0 * M_PI;
  euler_data[1] = filter.getPitch() / 180.0 * M_PI;
  euler_data[2] = (filter.getYaw() - 180.0) / 180.0 * M_PI;

  if (euler_data[0] < -M_PI) {
    euler_data[0] = euler_data[0] + 2 * M_PI;
  }
  if (euler_data[1] < -M_PI) {
    euler_data[1] = euler_data[1] + 2 * M_PI;
  }
  if (euler_data[2] < -M_PI) {
    euler_data[2] = euler_data[2] + 2 * M_PI;
  }

  if (euler_data[0] > M_PI) {
    euler_data[0] = euler_data[0] - 2 * M_PI;
  }
  if (euler_data[1] > M_PI) {
    euler_data[1] = euler_data[1] - 2 * M_PI;
  }
  if (euler_data[2] > M_PI) {
    euler_data[2] = euler_data[2] - 2 * M_PI;
  }


}
