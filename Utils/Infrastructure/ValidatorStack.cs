using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utils.Infrastructure
{
  public class MinValueAttribute : ValidationAttribute
  {
    private readonly int _maxValue;

    public MinValueAttribute(int maxValue)
    {
      _maxValue = maxValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      IComparable comparableValue = value as IComparable;
      return comparableValue.CompareTo(_maxValue as IComparable) >= 0 
                    ? ValidationResult.Success 
                    : new ValidationResult($"Value should be greater then {(_maxValue-1).ToString()}");
    }
  }
}
