using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

internal static class Utils {
    public static void Log(this Object me){
        Console.WriteLine(JsonConvert.SerializeObject(me));
    }

    public static Object ToErrorObject(this ModelStateDictionary d){
       return new {
           Errors = d.Values.Aggregate(
               new List<string>(),
               (acc, o) => {
                   foreach(var error in o.Errors)
                       acc.Add(error.ErrorMessage);

                   return acc;
               } 
           )
       };
   }
}