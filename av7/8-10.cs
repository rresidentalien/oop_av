public class Circle {
    public Circle(int x, int y, double radius) 
    {
        this.X = x; 
        this.Y = y; 
        this.Radius = radius;
    }
    public int X { get; private set; }
    public int Y { get; private set; }
    public double Radius { get; private set; }
}
public interface ICirclePicker 
{
    Circle PickMostSimilar ( Circle circle , List <Circle > circles );
    List <Circle > PickSimilar (Circle circle , List <Circle > circles , double differencePercent);
}
//8. zadatak - klasa koja nasljedjuje sucelje ICirclePicker
public double Area { get { return Radius * Radius * Math.Pi; } } //smijemo si ovako pomoci i nesto dodati (calculated property)
class AreaPicker : ICirclePicker
{
    public Circle PickMostSimilar(Circle circle, List<Circle> circles)
    {
        int mostSimilarIndex = 0;
        for(int i = 0; i < circles.Count; ++i)
        {
            if(
                Math.Abs(circle.Area - circles[i].Area < 
                Math.Abs(circle.Area - circles[mostSimilarIndex].Area))
            )
            {
                mostSimilarIndex = i;
            }
        }
        return circles[mostSimilarIndex];
    }

    public List<Circle> PickSimilar(Circle circle, List<Circle> circles, double differencePercent)
    {
        List<Circle> similarCircles = new List<Circle>();
        double minArea = circle.Area * (1.0 - differencePercent);
        double maxArea = circle.Area * (1.0 + differencePercent);

        foreach(Circle circle in circles)
        {
            if(circle.Area >= minArea && circle.Area <= maxArea)
            {
                similarCircles.Add(circle);
            }
        }
        return similarCircles;
    }
}





//9. zadatak
class Drawing
{
    Circle selectedCircle;
    List<Circle> circles; //ako nije eksplicitno zadana kolekcija, onda mi biramo
    ICirclePicker picker;
    public Drawing(Circle selectedCircle, List<Circle> circles, ICirclePicker picker)
    {
        this.selectedCircle = selectedCircle;
        this.circles = circles;
        this.picker = picker;
    }

    public void ChangePicker(ICirclePicker picker)
    {
        this.picker = picker;
    }
    public double CalculateTotalArea(double differencePercent)
    {
        List<circles> similarCircles = picker.PickSimilar(selectedCircle, circles, differencePercent);
        double totalArea = 0.0;
        foreach(Circle circle in similarCircles)
        {
            totalArea += circle.Area;
        }

        return totalArea;
    }
}






//10. zadatak
public static class RandomExtensions
{
    public static Circle NextCircle(this Random generator, double maxRadius)
    {
        double radius = 1.0 + generator.NextDouble() * (maxRadius - 1.0);
        return new Circle(generator.Next(), generator.Next(), radius);
    }
}


//za zadacu - dovrsiti zadatak - ucitati n, stvoriti random genrator, n puta stvoriti nasumicni krug, naci koji krug je najbilizi prvom stvorenom krugu (paziti da ga ne usporedjujemo s prvim)
//testove ne raditi ako se eksplicitno ne traze u zadatku