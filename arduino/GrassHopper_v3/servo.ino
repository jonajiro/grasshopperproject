void servo_init(void) {
  pwm.begin();                   //初期設定 (アドレス0x40用)
  pwm.setPWMFreq(50);            //PWM周期を60Hzに設定 (アドレス0x40用)
  //  servo_rotation(S_limbA, 90.0);
  //  servo_rotation(S_limbB, 90.0);
  //  servo_rotation(S_limbC, 90.0);
  for (int i = 0; i < sizeof(limb_angle); i++) {
    limb_angle[i] = 90.0 / 180.0 * M_PI;
  }
}

void servo_rotation(int ch, float ang) {
  ang = map(ang, 0, 180, SERVOMIN, SERVOMAX); //角度（0～180）をPWMのパルス幅（150～600）に変換
  pwm.setPWM(ch, 0, ang);
}
