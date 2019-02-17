using CommonLibrary;
using System;

namespace Using.ILRepack
{
    public class Dependent
    {
        public string Run() => new SomeClass().SomeMethod();
    }
}
