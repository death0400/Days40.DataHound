# Days40.DataHound
free custom compare to different both two instance



Getting Started
```C#
        public class ConsoleLog : ILogger
        {
            public Action<string> Onlog { get; set; } = Console.WriteLine;
        }

        static void Main(string[] args)
        {
            //register pattern and logger in the static Depandancy Injection Container
            HoundService.AddLogger<ConsoleLog>();
            // you can add more logger....
            // like HoundService.AddLogger<TelegramLogger>();
            HoundService.AddCompare<Dog, Man>(cfg =>
            {
                cfg.AddMap((dog, man) => dog.Name == man.DogName)
                .SetFailedMsg((dog, man) => $"the dog's name is {dog.Name},not belong to {man.Name}")
                .SetSuccessMsg("pass");

                cfg.AddMap((dog, man) => man.Age > 200 || dog.Age > 50)
                .SetFailedMsg("dog or man is too older,this is impossible");

                // add more pattern any you want ....
            });
            //it can be used any time、anywhere if you has been registered
            var hound = HoundService.GetHound<Dog, Man>();

            var poppy = new Dog { Name = "Abin", MasterName = "John", Age = 5 };
            var master = new Man { Name = "John", DogName = "Neo", Age = 200 };

            //start to check
            //out put the dog's name is Abin,not belong to John \r\n dog or man is too older,this is impossible
            hound.Check(poppy, master);

            //you can pattern many instances also
            var dogs = new List<Dog>
            {
                new Dog { Name = "Neo", Age = 20 },
                new Dog { Name = "Melody", Age = 30 },
                new Dog { Name = "Paul", Age = 18 }
            };
            dogs.ForEach(dog => hound.Check(dog, master));
            Console.ReadKey();
        }
```

Next Version

Maybe add the pattern for IEnumerable by IEnumerable and custom logger to specific map，automap or autotransfer bla bla bla
