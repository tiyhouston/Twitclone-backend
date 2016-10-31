using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("/api/card")]
public class CardController : CRUDController<Card> {
    public CardController(IRepository<Card> r) : base(r){}
}

[Route("/api/cardlist")]
public class CardListController : CRUDController<CardList> {
    public CardListController(IRepository<CardList> r) : base(r){}
}

[Route("/api/board")]
public class BoardController : CRUDController<Board> {
    public BoardController(IRepository<Board> r) : base(r){}
}