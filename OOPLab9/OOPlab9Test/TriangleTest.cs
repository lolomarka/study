using Xunit;
using OOPlab9;
using System;

public class TestTriangle
{
    [Fact]
    public void TriangleConstructorWithoutParams()
    {
        //arrange
        double aExp = 0.0;
        double bExp = 0.0;
        double cExp = 0.0;

        //act
        Triangle tri = new Triangle();

        //assert
        Assert.Equal(aExp,tri.A);
        Assert.Equal(bExp,tri.B);
        Assert.Equal(cExp,tri.C);
    }

    [Fact]
    public void TriangleConstructorWithParams()
    {
        //arrange
        
        //a,b,c < 0
        double a1 = -5;
        double b1 = -3;
        double c1 = -4;

        double a1Exp = 0.0;
        double b1Exp = 0.0;
        double c1Exp = 0.0;

        //a,b,c > 0
        double a2 = 5;
        double b2 = 5;
        double c2 = 5;

        double a2Exp = 5;
        double b2Exp = 5;
        double c2Exp = 5;

        //act
        Triangle tri1 = new Triangle(a1,b1,c1);

        Triangle tri2 = new Triangle(a2,b2,c2);

        //assert
        Assert.Equal(a1Exp,tri1.A);
        Assert.Equal(b1Exp,tri1.B);
        Assert.Equal(c1Exp,tri1.C);

        Assert.Equal(a2Exp,tri2.A);
        Assert.Equal(b2Exp,tri2.B);
        Assert.Equal(c2Exp,tri2.C);
    }

    [Fact]
    public void TriangleAttributeSet()
    {
        //arrange
        
        //new a,b,c < 0
        double a1 = 5;
        double b1 = 3;
        double c1 = 4;

        double newA1 = -5;
        double newB1 = -5;
        double newC1 = -5;

        double a1Exp = 5;
        double b1Exp = 3;
        double c1Exp = 4;

        //new a,b,c > 0
        double a2 = 5;
        double b2 = 5;
        double c2 = 5;

        double newA2 = 4;
        double newB2 = 3;
        double newC2 = 2;

        double a2Exp = 4;
        double b2Exp = 3;
        double c2Exp = 2;

        //act
        Triangle tri1 = new Triangle(a1,b1,c1);
        tri1.A = newA1;
        tri1.B = newB1;
        tri1.C = newC1;

        Triangle tri2 = new Triangle(a2,b2,c2);
        tri2.A = newA2;
        tri2.B = newB2;
        tri2.C = newC2;


        //assert
        Assert.Equal(a1Exp,tri1.A);
        Assert.Equal(b1Exp,tri1.B);
        Assert.Equal(c1Exp,tri1.C);

        Assert.Equal(a2Exp,tri2.A);
        Assert.Equal(b2Exp,tri2.B);
        Assert.Equal(c2Exp,tri2.C);
    }
    

    [Theory]
    [InlineData (0,0,0,0)]
    [InlineData (3,4,5,6)]
    [InlineData (4,5,6,9.921567416492215)]
    public void TriangleAreaGet(double a, double b, double c, double s)
    {
        //Создание треугольника
        Triangle tri = new Triangle(a,b,c);
        //Проверка, на совпадение площадей с заданным
        Assert.Equal(s,tri.AreaOfTriangle());
    }


    [Theory]
    [InlineData (0,0,0,1,1,1)]
    [InlineData (1,2,3,2,3,4)]
    [InlineData (4,4,4,5,5,5)]
    [InlineData (-1,-1,-1,1,1,1)]
    public void TriangleIncrement(double a, double b,double c,double a1,double b1,double c1)
    {
        Triangle tri = new Triangle(a,b,c);

        tri++;

        Assert.Equal(a1,tri.A);
        Assert.Equal(b1,tri.B);
        Assert.Equal(c1,tri.C);
    }

    [Theory]
    [InlineData (0,0,0,0,0,0)]
    [InlineData (1,2,3,0,1,2)]
    [InlineData (4,4,4,3,3,3)]
    [InlineData (-1,-1,-1,0,0,0)]
    public void TriangleDecrement(double a, double b,double c,double a1,double b1,double c1)
    {
        Triangle tri = new Triangle(a,b,c);

        tri--;

        Assert.Equal(a1,tri.A);
        Assert.Equal(b1,tri.B);
        Assert.Equal(c1,tri.C);
    }


    [Theory]
    [InlineData(0,0,0,-1)]
    [InlineData(3,4,5,6)]
    public void TriangleExplicitConverting(double a,double b, double c,double sExp)
    {
        Triangle tri = new Triangle(a,b,c);

        Assert.Equal(sExp,(double)tri);
    }
    

    [Theory]
    [InlineData(3,4,5,true)]
    [InlineData(0,0,0,false)]
    [InlineData(-1,-1,1,false)]
    [InlineData(3,2,5,false)]
    public void TriangleImplicitConverting(double a,double b, double c,bool flExp)
    {
        Triangle tri = new Triangle(a,b,c);
        bool boo = tri;
        Assert.Equal(flExp,boo);
    }

    [Theory]
    [InlineData(3,4,5,0,0,0,true)]
    [InlineData(3,4,5,5,4,3,true)]
    [InlineData(0,0,0,3,4,5,false)]
    public void TriangleCompareMoreOrEqual(double a,double b, double c,double a1,double b1, double c1, bool flExp)
    {
        bool boo = new Triangle(a,b,c) >= new Triangle(a1,b1,c1);
        Assert.Equal(flExp,boo);
    }

    [Theory]
    [InlineData(3,4,5,0,0,0,false)]
    [InlineData(3,4,5,5,4,3,true)]
    [InlineData(0,0,0,3,4,5,true)]
    public void TriangleCompareLessOrEqual(double a,double b, double c,double a1,double b1, double c1, bool flExp)
    {
        bool boo = new Triangle(a,b,c) <= new Triangle(a1,b1,c1);
        Assert.Equal(flExp,boo);
    }

    [Theory]
    [InlineData(3,4,5,0,0,0,true)]
    [InlineData(3,4,5,5,4,3,false)]
    [InlineData(0,0,0,3,4,5,false)]
    public void TriangleCompareMore(double a,double b, double c,double a1,double b1, double c1, bool flExp)
    {
        bool boo = new Triangle(a,b,c) > new Triangle(a1,b1,c1);
        Assert.Equal(flExp,boo);
    }

    [Theory]
    [InlineData(3,4,5,0,0,0,false)]
    [InlineData(3,4,5,5,4,3,false)]
    [InlineData(0,0,0,3,4,5,true)]
    public void TriangleCompareLess(double a,double b, double c,double a1,double b1, double c1, bool flExp)
    {
        bool boo = new Triangle(a,b,c) < new Triangle(a1,b1,c1);
        Assert.Equal(flExp,boo);
    }


    [Theory]           
    [InlineData (0,0,0,"Длины катетов:\nA = 0;\nB = 0;\nC = 0;\nЭкземпляров класса создано: 1.\nПлощадь равна: 0\n")]
    [InlineData (3,4,5,"Длины катетов:\nA = 3;\nB = 4;\nC = 5;\nЭкземпляров класса создано: 1.\nПлощадь равна: 6\n")]
    public void TriangleInfoToString(double a1, double b1, double c1, string str1)
    {
        Triangle t = new Triangle();
        t.SetInstanceToZero();

        Triangle tri = new Triangle(a1,b1,c1);

        Assert.Equal(str1,tri.GetInformationToString);

    }


    [Fact]
    public void TriangleSetInstanceToZero()
    {
        int InstExp = 0;

        Triangle tri = new Triangle();

        Assert.NotEqual(InstExp,tri.Instance);

        tri.SetInstanceToZero();

        Assert.Equal(InstExp, tri.Instance);
    }

    [Theory]
    [InlineData (0,0,0,"0")]
    [InlineData (3,4,5,"6")]
    [InlineData (1,2,4,"0")]
    public void TriangleAreaOfTriangleToString(double a1,double b1, double c1, string result)
    {
        Triangle tri = new Triangle(a1,b1,c1);

        Assert.Equal(result,tri.AreaOfTriangleToString());
    }
    

}