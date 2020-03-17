﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Parcial2.Validaciones
{
    class ProblemaValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                string problema = Convert.ToString(value);

                if (problema.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Problema");

                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debe Tener un Campo");
        }
    }
}
