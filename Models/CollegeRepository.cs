namespace webapplication1.Models
{
    public static class CollegeRepository
    {
       public static List<Student> Students {  get; set; } =  new List<Student>(){ new Student
            {
                Id=1,
                Studentname="preetika",
                email="abc@gmail.com",
                Address="xyz street",
                city="kanpur"
            },
            new Student{
                    Id = 2,
                Studentname = "Raj",
                email = "def@gmail.com",
                Address = "abc street",
                city = "jaipur"
            }
            };
    }
}
