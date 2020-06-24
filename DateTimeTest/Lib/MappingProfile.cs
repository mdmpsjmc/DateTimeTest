using AutoMapper;
using DateTimeTest.Models;
using DateTimeTest.Models.ViewModels;


namespace DateTimeTest.Lib
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NewPatientViewModel, Patient>();
        }
    }
}
