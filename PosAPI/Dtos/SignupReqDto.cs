namespace PosAPI.Dtos
{
    public class SignupReqDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }   
        public int UserRole { get; set; }           
    }
}