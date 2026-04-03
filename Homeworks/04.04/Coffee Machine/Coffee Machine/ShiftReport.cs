namespace Coffee_Machine;

public class ShiftReport
{
    public DateTime ReportDate { get; set; }
    public int TotalRevenue { get; set; }
    public int SalesAmount { get; set; }

    public ShiftReport(){}
    
    public ShiftReport(DateTime date, int totalRevenue, int salesAmount)
    {
        ReportDate = date;
        TotalRevenue = totalRevenue;
        SalesAmount = salesAmount;
    }
}