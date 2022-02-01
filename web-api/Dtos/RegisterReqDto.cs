namespace web_api.Dtos
{
    public class RegisterReqDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }   
        public int UserRole { get; set; }     
    }
}