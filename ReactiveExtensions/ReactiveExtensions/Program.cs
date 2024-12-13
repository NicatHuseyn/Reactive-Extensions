


//MyObservable observable = new();

//using (observable.Subscribe(new MyObserver1()))
//using (observable.Subscribe(new MyObserver2()))
//{
//    observable.NotifyObservers(5);
//    observable.NotifyObservers(10);
//}



//class MyObservable : IObservable<int>
//{
//    List<IObserver<int>> observers = new();
//    public IDisposable Subscribe(IObserver<int> observer)
//    {
//        if (!observers.Contains(observer))
//            observers.Add(observer);

//        return new Unsubscription(() =>
//        {
//            observers.Remove(observer);
//            observer.OnCompleted();
//        });
//    }

//    public void NotifyObservers(int value) => observers.ForEach(observer=>observer.OnNext(value));
//}



//class Unsubscription(Action unsubscribe) : IDisposable
//{
//    public void Dispose()
//    {
//        unsubscribe?.Invoke();
//        unsubscribe = null;
//    }
//}


//class MyObserver1 : IObserver<int>
//{
//    public void OnCompleted() => 
//        Console.WriteLine($"{nameof(MyObserver1)} - Observation completed");
//    public void OnError(Exception error)=> 
//        Console.WriteLine($"{nameof(MyObserver1)} - Error: {error.Message}");
//    public void OnNext(int value)=> 
//        Console.WriteLine($"{nameof(MyObserver1)} - Received value: {value}");
//}

//class MyObserver2 : IObserver<int>
//{
//    public void OnCompleted() => Console.WriteLine($"{nameof(MyObserver2)} - Observation completed");
//    public void OnError(Exception error) => Console.WriteLine($"{nameof(MyObserver2)} - Error: {error.Message}");
//    public void OnNext(int value) => Console.WriteLine($"{nameof(MyObserver2)} - Received value: {value}");
//}




//#region News App


//NewsFeed newsFeed = new NewsFeed();

//User user1 = new("Nijat Huseynov");
//User user2 = new("Agil Murguzov");

//using var user1Subscribion1 = newsFeed.Subscribe(user1);
//using var user1Subscribion2 = newsFeed.Subscribe(user2);

//newsFeed.PublishNews(new() { Category = "Technology", Title = "IPhone 20 is create"});
//newsFeed.PublishNews(new() { Category = "Sport", Title = "Karabakh is the world champion" });


//class NewsItem
//{
//    public string Category { get; set; }
//    public string Title { get; set; }
//}

//class NewsFeed : IObservable<NewsItem>
//{
//    List<IObserver<NewsItem>> observers = new();

//    public IDisposable Subscribe(IObserver<NewsItem> observer)
//    {
//        if (!observers.Contains(observer))
//            observers.Add(observer);

//        return new Unsubscription(() =>
//        {
//            observers.Remove(observer);
//            observer.OnCompleted();
//        });
//    }

//    public void PublishNews(NewsItem newsItem) => observers.ForEach(observer=>observer.OnNext(newsItem));
//}




//class User(string fullName) : IObserver<NewsItem>
//{
//    public void OnCompleted()
//        => Console.WriteLine($"{fullName}, news subscription completed");

//    public void OnError(Exception error)
//        => Console.WriteLine($"{fullName}, Error: {error.Message}");

//    public void OnNext(NewsItem value)
//        => Console.WriteLine($"{fullName}, new news is category '{value.Category}' - '{value.Title}'");
//}


//class Unsubscription(Action unSubscription) : IDisposable
//{
//    public void Dispose()
//    {
//        unSubscription?.Invoke();
//        unSubscription = null;
//    }
//}

//#endregion


#region ISubject Interface

using System.Reactive.Subjects;

ISubject<int> subject = new Subject<int>();

MyObserver observerA = new MyObserver("A");
MyObserver observerB = new MyObserver("B");
MyObserver observerC = new MyObserver("C");

var aSub = subject.Subscribe(observerA);
var bSub = subject.Subscribe(observerB);
var cSub = subject.Subscribe(observerC);

subject.OnNext(1);
subject.OnNext(2);
subject.OnNext(3);

bSub.Dispose();

subject.OnNext(1);
subject.OnNext(2);
subject.OnNext(3);



class MyObserver(string name) : IObserver<int>
{
    public void OnCompleted() =>
        Console.WriteLine($"{name} - Observation completed");
    public void OnError(Exception error) =>
        Console.WriteLine($"{name} - Error: {error.Message}");
    public void OnNext(int value) =>
        Console.WriteLine($"{name} - Received value: {value}");
}



#endregion