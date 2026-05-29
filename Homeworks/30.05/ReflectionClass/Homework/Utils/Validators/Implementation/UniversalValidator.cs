using System.Reflection;
using ReflectionClass.Homework.Utils.Validators.Abstraction;
using ReflectionClass.MiniFrameworkImplementation.Attributes; 

namespace ReflectionClass.Homework.Utils.Validators.Implementation;

public class UniversalValidator : IValidator
{
        /// <summary>
        /// Универсальный метод, который валидирует ВООБЩЕ любой объект на основе его атрибутов.
        /// </summary>
        public bool Validate(object? obj, out List<string> errors)
        {
            errors = new List<string>();
            // TODO: Проверить на null
            if (obj == null)
            {
                errors.Add("Object is null");
                return false;
            }
            
            // TODO: ШАГ 1. Получить тип объекта 
            var type = obj.GetType();
            
            // TODO: ШАГ 2. Извлечь все свойства
            var properties = type.GetProperties();
            
            // TODO: ШАГ 3. Получать все значения свойств у ТЕКУЩЕГО экземпляра

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                // TODO: ШАГ 3.1 Проверять, обвешано ли свойство атрибутом MyRequired
                var requiredAttribute = property.GetCustomAttribute<MyRequiredAttribute>();
                if (requiredAttribute != null)
                {
                    if (value == null || (value is string str && string.IsNullOrEmpty(str)))
                    {
                        errors.Add($"Property '{property.Name}' is required.");
                    }
                }

                // TODO: ШАГ 3.2 Проверять, есть ли атрибут MyRange
                var rangeAttribute = property.GetCustomAttribute<MyRangeAttribute>();
                if (rangeAttribute != null)
                {
                    if (value is int intValue)
                    {
                        if (intValue < rangeAttribute.Min || intValue > rangeAttribute.Max)
                        {
                            errors.Add($"Property '{property.Name}' value {intValue} is out of range [{rangeAttribute.Min}-{rangeAttribute.Max}].");
                        }
                    }
                }
            }
            return errors.Count == 0;
        }
}