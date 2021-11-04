// ITSE 1430
// Movie Library
// Jonathan Daniel

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class ObjectValidator
    {
        public IEnumerable<ValidationResult> TryValidate ( IValidatableObject instance )
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(instance);

            Validator.TryValidateObject(instance, context, errors);

            return errors;
        }

        public bool TryValidate ( IValidatableObject instance, out string error )
        {
            var errors = TryValidate(instance);
            error = errors.FirstOrDefault()?.ErrorMessage;

            return String.IsNullOrEmpty(error);
        }
    }
}
