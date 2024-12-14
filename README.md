
  <h1>IObservable & IObserver | Reactive Extensions Rx</h1>

  <p>
      C# proqramlaşdırma dilində, Reactive Extensions (Rx) kitabxanasında olan
      IObservable və IObserver interfeysləri, bir obyektin mövcud vəziyyətində
      edilən dəyişiklikləri başqa obyektlərə bildirmək üçün müşhaidə
      (observables) və müşhaidəçi (observers) patter-ini həyata keçirmək üçün
      istifadə edilən strukturlardır.
    </p>

  <h3><strong>Observables və Observers pattern-I nədir?</strong></h3>

  <p>
      Bu pattern-də, xüsusilə bir obyektin state dəyişəndə və bu dəyişgənlik
      başqa obyektlər tərəfindən track edilmək istənildiyində istifadə edilə
      bilər. Dəyişiklikləri track etmək istəyən obyektlərə
      <strong>“müşhaidəçi (observer)”</strong>, dəyişiklikləri track edilməsi
      istənilən obyekt isə
      <strong>“müşhaidə edilə bilən (observable)”</strong> deyilir.
    </p>

  <p>
      Buna nümunə olaraq belə bir nümunə verə bilərik. Məsələn, bir ana, ata və
      uşağı var. Ana və ata uşağa nəzarət etməlidir (track etməli). Burada ata
      və ana observer, uşağ isə observable-dir.
      <br />
      Observable obyekt, bir və daha çox observer-I save edir və onlara
      dəyişikliklər haqqında xəbər verir. Necə ki, uşaq ana və atasını özündə
      save edir. <br />
      Yəni, bir növ notification davranışı ortaya qoyur. Observer isə observable
      obyektinin state-ində meydana gələn dəyişiklikləri gördükdə əməliyyatları
      həyata keçirir.
    </p>

  <h3>Bu pattern-in avantajları nələrdir?</h3>
    <p>
      Bu pattern-in bir çox avantajı vardır. Ilk olaraq obyektlər arasında
      loosely coupled vəziyyəti olduqda dəyişikliklərin təsirləri sürətlə yayıla
      bilər və sadəcə əlaqəli obyektlər bu dəyişikliklərdən təsir görər. Bu
      pattern sayəsində hansı obyektlərə təsir göstəribsə, bu barədə
      notification ala bilərik.
      <br />
      Bundan əlavə yeni bir observer əlavə etmək və ya mövcud bir observer-I
      silmək olduqca asandır. Observer sayı və ya tipi dəyişəndə observable
      obyektin kodunda heç bir dəyişiklik etməyə ehtiyac yoxdur.
      <br />
      Həmçinin observer-ların bir-birindən asılı olmadan xəbərsizcə çalışmaları
      da bir avantajdır.
      <br />
      Bu pattern, event based, asinxron proqramlaşdırmada, distributed
      sistemlərdə, GUİ (Graphical User İnterface) dizaynlarında istifadə edilir.
      <br />
      C#-da IObserver və IObservable interfeysləri ilə bu pattern-ləri həyata
      keçirmək olur.
    </p>
    <br />

  <strong>IObservable:</strong>
    <p>
      State-ində dəyişiklik olduqda, başqa obyektlər tərəfindən track ediləcək
      olan, yəni notification verəcək olan obyekti işarələdiyimiz interfeysdir.
    </p>
    <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/8adc3810-9d93-4ab8-a380-a8f9da60f4d1" alt="" />
    </div>
    <p>
      Burada bunu da qeyd etmək lazımdır ki, biz bir Observable obyekti
      yaradacağıq, bunun üçün IObservable interfeysindən istifadə edəcəyik. Bu
      class-ı track edəcək obyektləri abunə edəcək bir davranış ortaya
      qoymalıdır. Bu davranışı da interfeysin içərisindəki Subscribe olaraq
      əlaqəli class-a qazandıracaqdır. Adı üzərində, subscribe, bu class-a abunə
      olana bilən bir özəllik verəcək
    </p>
    <br />

  <strong>IObserver:</strong>
    <p>
      Observable olan obyekti track edən və notification almaq istəyən obyekti
      təmsil edən interfeysdir.
    </p>

  <div style="width: 400px">
      <img style="width: 400px" src="https://github.com/user-attachments/assets/574632e9-4e18-4ed3-84d5-ad4633448381" alt="" />
    </div>

  <p>
      Burada 3 ədəd fərqli metod görürük, bunlar da IObservable interfeysi ilə
      implement edilmiş müşhaidə edilə bilən obyektin state-ində ola biləcək
      dəyişiklərin tipinə görə tətiklənəcək olan davranışları təmsil edir.
      <br />
      Burada hər state dəyişikliyinə qarşı bir notification məntiqində davranış
      ortaya qoyulacaqsa, bunu <strong>OnNext(T value)</strong> metou ilə
      edəcəyik.
      <br />
      Bir observable-də bir error olarsa, bunu OnError(Exception error) metodu
      ilə ifadə edirik.
      <br />
      Əgər observer, observable obyektini tracking-dən çıxırsa və ya observable
      bu obyekti çıxarırsa, bu zaman <strong>OnCompleted()</strong> ilə ifadə
      ediri.
    </p>
    <br />

  <h1>İndi isə kod tərəfində baxaq</h1>

  <p>Ilk olaraq əməliyyatları track ediləcək observable obyekti yaradaq</p>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/28a299b2-eab5-4023-ba1c-61327c5ca723" alt="" />
    </div>

  <h3><strong>Koda nəzər salaq:</strong></h3>

  <ol>
      <li>
        MyObservable class-ını IObservable interfeysini implement edirik və
        Subscribe metodu avtomatik olaraq gəlir.
      </li>
      <li>
        Burada List ilə MyObservable obyektinə abunə olacaq observer-ləri
        saxlayırıq.
      </li>
      <li>
        if şərti içərisində yoxlayırıq ki, əgər abunə olmaq istəyən obyekt əgər
        abunə olmuşların arasında yoxdursa, observable obyektinə abunə edir.
      </li>

  <li>
        Gördüyümüz kimi Subscribe metodu IDisposable geri döndür, buna görə də
        bizə bir IDisposable interfeysini implement edən bir class-a ehtiyacımız
        var. Bunun üçündə aşağıdakı class-ı yazırıq.
        <br />
        <div style="width: 400px">
          <img style="width: 400px" src="https://github.com/user-attachments/assets/56b833b5-c48e-497d-8e9d-41344315d625" alt="" />
        </div>
        <br />
        <p>
          Burada görürük ki, constructor-undan bir parametr alır və IDisposable
          interfeysini implement etdiyinə görə Dispose funksiyası gəlir və bu
          funksiyanın içərisində unsubscribe-a qarşı olan Action metodu
          tətikləyir və dispose edir.
          <br />
          <strong>Bəs bunu niyə edir?</strong>
          Bu obyekt constructor-undan bir metod alır. Bizlər adətən bu metod
          içərisində, əlaqəli obyekt, yəni Unsubscription obyekti dispose
          edildikdə subscribe edilmiş olan observer-i collection-dan çıxarmaq
          işini həyata keçirir. Beləcə dispose davranışı yaddaş idarəsindən
          başqa daha çox iş görür.
        </p>
      </li>

  <li>
        5. Buradakı <strong>NotifyObserver()</strong> metodu ilə bu obyekti
        track edən bütün observer-lara notify göndərilir.
      </li>
    </ol>

  <h3>İndi isə observer class-larımız yazaq</h3>
    <p>İstədiyimiz qədər observer yarada bilərik.</p>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/052d2997-71cc-4114-8318-2b2d6ad6f446" alt="" />
    </div>
    <p>
      Iki ədəd bu şəkildə observer class-ı yaratdıq. İndi isə geriyə qalan, bu
      vəziyyətdə çalışdırmaq.
    </p>

  <div style="width: 400px">
      <img style="width: 400px" src="https://github.com/user-attachments/assets/d6503321-83db-4154-840f-78a749fc7551" alt="" />
    </div>

  <p>
      Görüldüyü kimi bir observable class-ı yaradıb, digər yazdığımız
      observer-ları subscribe edirik. Nə vaxt
      <strong>NotifyObservers</strong> metodunu çağırsaq, bu zaman subscribe
      olmuş bütün obyektlər tətiklənəcək. Nə vaxt ki, Observer-lər işlərini
      bitirəcək, bu zaman dispose ediləcək və subscribe olduqları Observable
      obyektini subscribe-ındən çıxacaq.
    </p>

  <h3>Indi isə bir xəbər gedişatı proqramı üzərindən gedək.</h3>
    <br />
    <p>
      Burada, fərqli xəbər kateqoriyalarında yeni xəbərləri bildirən bir
      NewsFeed class-ı olacaq. Eyni zamanda user-in seçdiyi xəbər
      kateqoriyalarına abunə olan User class-ı olacaq. Hər yeni xəbər gəldikdə,
      user-lər notification gedəcək.
    </p>

  <div style="width: 400px">
      <img style="width: 400px" src="https://github.com/user-attachments/assets/7af715bf-dd4e-4f83-8cb6-2bfca72e0505" alt="" />
    </div>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/fcf244f3-c0f1-4620-b302-f10d4dfbbb27" alt="" />
    </div>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/9e7a05ef-6e4b-4ecd-beef-dbff5d5d9988" alt="" />
    </div>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/adeb0373-2c8a-4780-923f-ea370b9dedb7" alt="" />
    </div>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/2faaa412-7319-4153-9955-53aecbdc6e2e" alt="" />
    </div>

  <br />

  <h1><strong>ISubject Interface</strong></h1>

  <p>
      ISubject, Reactive Extensions (Rx) kitabxanasında olan və IObservable və
      IObserver interfeyslərini birləşdirən interfeysdir.
      <br />
      Yəni ISubject interfeysi bu iki interfeyslərin əməliyyat zamanı hərəkətə
      keçməsində və idarə edilməsində məsuliyyət daşıyan interfeysdir.
      <br />
      Biz ilk öncə <strong>System.Reactive</strong> yükləməliyik.
    </p>

  <div style="width: 400px">
      <img style="width: 400px" src="https://github.com/user-attachments/assets/b012d677-4bca-48a6-b67f-74b8e3eec6ef" alt="" />
    </div>
    <p>
      Biz Isubject-in atalarına getsək görərik ki, bu həm IObserver-dən həm də
      IObservable-dən implement olunur.
    </p>
    <strong>Məsələn, aşağıdakı koda baxaq::</strong>

  <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/5a231ca1-2553-46ca-a720-1dd7b26bed12" alt="" />
    </div>
    <div style="width: 700px">
      <img style="width: 700px" src="https://github.com/user-attachments/assets/8ba58c37-e6b1-435e-91ea-31ed1a001a91" alt="" />
    </div>

  <p>Və nəticə</p>

  <div style="width: 400px">
      <img style="width: 400px" src="https://github.com/user-attachments/assets/5e7f33a8-bd0c-4e8f-b1db-ca1728b6d846" alt="" />
    </div>
