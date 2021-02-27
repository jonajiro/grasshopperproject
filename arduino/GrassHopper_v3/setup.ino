void my_setup(void) {
  Serial.begin(115200);
  SerialBT.begin("ESP32");
  delay(200);

  M5.begin();
  Wire.begin(0, 26);

  servo_init();
  sensor_init();
  data_init();
  IntervalSet(dt);
}

void data_init(void) {
  for (int i = 0; i < Si1buf_size; i++)Serial1_buffer[i] = 0x00;
  Serial1_buffer_len = 0;
}

void IntervalSet(float interupt_time) {
  ticker_timer.attach(interupt_time, timer_1);
}
