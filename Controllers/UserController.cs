using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/user")]  ///fix this tomorrow

public class UserAPIController : CRUDController<User> {
    //private IRepository<User> users;
    public UserAPIController(IRepository<User> u) : base(u){
        //users = u;
    }
}