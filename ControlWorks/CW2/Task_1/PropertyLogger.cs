namespace Task_1;

public class PropertyLogger
{
    public List<string> properties = new();
    public void GetLog(object obj)
    {
        //Метод GetLog(object obj) должен через рефлексию вернуть список строк (НЕ ВЫВЕСТИ В КОНСОЛЬ) 
        //"[ИмяСвойства]: [Значение]" для всех свойств, у которых значение не null.
        
        var propertiesObject = obj.GetType().GetProperties();
        foreach (var property in propertiesObject)
        {
            if (property.GetValue(obj) != null)
            {
                properties.Add($"[{property.Name}]: {property.GetValue(obj)}");
            }
        }
    }
}