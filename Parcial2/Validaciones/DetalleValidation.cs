using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Parcial2.Validaciones
{
    class DetalleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "debe Agregar un campo para Guardar");
        }
    }
}
