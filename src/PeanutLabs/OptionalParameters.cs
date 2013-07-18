using System;

namespace PeanutLabs
{
    public class OptionalParameters
    {
        private readonly DateTime? _birthDate;
        private readonly Gender _gender;

        public OptionalParameters(DateTime birthDate)
            : this(birthDate, Gender.Unset)
        {
        }

        public OptionalParameters(Gender gender)
            : this(null, gender)
        {
        }

        public OptionalParameters(DateTime? birthDate, Gender gender)
        {
            _birthDate = birthDate;
            _gender = gender;
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
        }

        public Gender Gender
        {
            get { return _gender; }
        }
    }
}