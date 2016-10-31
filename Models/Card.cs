using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class Card : HasId
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

public class CardList : HasId {
    public int Id { get; set; }
    public string Summary { get; set; }
    public List<Card> Cards { get; set; }
}

public class Board : HasId {
    public int Id { get; set; }
    public List<CardList> Lists { get; set; }
}