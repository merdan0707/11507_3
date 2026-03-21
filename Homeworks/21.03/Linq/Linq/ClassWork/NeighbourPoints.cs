namespace Linq;


public record Point(int X, int Y);

public class NeighbourPoints
{
    public static void Run()
    {
        var center =  new Point(3,3);
        var neighbourPoints = GetNeighbours(center);
        
        foreach (var point in neighbourPoints)
        {
            Console.WriteLine(point);
        }
    }
    
    
    public static IEnumerable<Point> GetNeighbours(Point p)
    {
        int[] d = {-1, 0, 1};

        #region Query Syntax
        
        return 
            from dx in d
            from dy in d 
            let neighbour = new Point(p.X + dx,p.Y + dy)
            where !neighbour.Equals(p)   
            select neighbour;
        
        #endregion
        
        #region Method Syntax
        
        // return d
        //     .SelectMany(dx => d, (dx, dy) => new Point(p.X + dx, p.Y + dy)) 
        //     .Where(neighbour => !neighbour.Equals(p));
        
        #endregion
    }
    
    
}