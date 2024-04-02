using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Operation.Pages.Clients
{
    public class createModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String erroMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo address = Request.Form["address"];

            if(clientInfo.Name.Length == 0 || clientInfo.Email.Length == 0 ||
               clientInfo.Phone.Length == 0 || clientInfo.Address.Length == 0)
            {
                erroMessage = "All the Fields are required";
                return;
            }
        }
    }
}
