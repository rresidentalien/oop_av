public abstract class IotSensor {
    protected int samplingRateHz ; // in Hz ( samples per second), > 0
    protected double batteryPercent ; // in percent , in range [0, 100]
    protected double samplePowerDraw ; // percent of battery required for each sample
}
//5. zadatak - parametarski konstruktor, metoda koja racuna preostalo vrijeme rada senzora, metoda koja za predan broj sekundi rada racuna koliko je uzoraka moguce obraditi
protected IotSensor (int samplingRateHz, double batteryPercent, double samplePowerDraw)
{
    this.samplingRateHz = samplingRateHz > 0 ? samplingRateHz : 1; //ovo smo mogli rjesiti i s Math.Max
    this.batteryPercent = Math.Clamp(batteryPercent, 0, 100);
    this.samplePowerDraw = samplePowerDraw;
}
public int CalculateRemainingTime()
{
    int samples = (int)(batteryPercent / samplePowerDraw);
    int time = samples / samplingRateHz;
    return time;
}
public int CalculateMaxSamples(int seconds)
{
    int time = Math.Min(CalculateRemainingTime(), seconds);
    int samplesCount = time * samplingRateHz;
    return samplesCount;
}






//6. zadatak
//(iz IotSensor)
public abstract List<Measurement> Measure(DateTime start, DateTime stop) //mogli smo staviti i TimeSpan, int seconds
{

}
abstract class Measurement
{
    public abstract DateTime MeasuredAt {get;}
    public abstract string CreateReport();
}






//7. zadatak
class SensorArray
{
    //jagged array:
    IotSensor[][] sensor;
    public SensorArray(int rows, int columns)
    {
        sensors = new IotSensor[rows][];
        for (int i = 0; i <sensors.Length; ++i)
        {
            sensors[i] new IotSensor[columns];
        }
    }

    public void Insert(IotSensor sensor, int row, int column)
    {
        sensors[row][column] = sensor;
    }
    public int DetermineRemainingTime()
    {
        int time = 0; //rubni slucaj - ako je cijela matrica prazna, preostalo vrijeme je 0
        foreach(var sensorRow in sensors)
        {
            foreach(var sensor in sensorRow)
            {
                if(sensor != null)
                {
                    if(sensor.CalculateRemainingTime() == 0)
                    {
                        throw new SensorFailException();
                    }
                    if(time == 0 || sensor.CalculateRemainingTime() < time)
                    {
                        time = sensor.CalculateRemainingTime();
                    }
                }
            }
        }
        return time;
    }
}
class SensorFailException : Exception
{
    public SensorFailException() { }
    public SensorFailException(string message) : base(message) { }
}