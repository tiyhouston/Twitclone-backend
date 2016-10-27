/*
The following is an IRepository pattern. We write our logic to do CRUD operations on a model 
(i.e. in the database, in memory, etc). From our controllers, we can feed the IRepository to
each controller via Dependency Injection:

services.AddSingleton<IRepository<Post>, PostRepo>();

Then each Controller can opt to accept it as an input:

public PostController(DB db, IRepository<Post> r){
    ...
}

*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

public interface IRepository<T>
{
    void Create(T item);
    IEnumerable<T> Read();
    T Read(int id);
    void Update(T item);
    T Delete(int id);
}

/*
public class PostRepo : IRepository<Post> {

    private static ConcurrentDictionary<int, Post> ls = new ConcurrentDictionary<int, Post>();
    
    public void Create(Post item){
        // item.PostId = Guid.NewGuid(); // to uncommment, will have to change PostId to Guid in the Models
        ls[item.PostId] = item;
    }
    
    public IEnumerable<Post> Read(){
        return ls.Values;
    }
    
    public Post Read(int id){
        return ls[id];
    }
    
    public void Update(Post item){
        ls[item.PostId] = item;
    }
    
    public Post Delete(int id){
        Post item;
        ls.TryRemove(id, out item);
        return item;
    }

}
*/