using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("/api/tweet")]
public class TweetController : CRUDController<Tweet> {
    public TweetController(IRepository<Tweet> t) : base(t){}
}

// [Route("/api/cardlist")]
// public class CardListController : CRUDController<CardList> {
//     public CardListController(IRepository<CardList> r) : base(r){}
// }

// [Route("/api/board")]
// public class BoardController : CRUDController<Board> {
//     public BoardController(IRepository<Board> r) : base(r){}
// }