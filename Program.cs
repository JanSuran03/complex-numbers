using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex_numbers
{

   public class complexNumber
   {
      public double realPart;
      public double imaginaryPart;

      public complexNumber(double realPart, double imaginaryPart)
      {
         //Console.WriteLine(realPart + "; " + imaginaryPart);
         this.realPart = realPart;
         this.imaginaryPart = imaginaryPart;
         Console.WriteLine("A new complex number Re = " + realPart + ", Im = " + imaginaryPart + " has been created.");
      }

      public complexNumber addComplexNumber(complexNumber num2)
      {
         return new complexNumber(this.realPart + num2.realPart, this.imaginaryPart + num2.imaginaryPart);
      }

      public complexNumber multiplyWithComplexNumber(complexNumber num2)
      {
         double RP1 = this.realPart;
         double IP1 = this.imaginaryPart;
         double RP2 = num2.realPart;
         double IP2 = num2.imaginaryPart;
         double newRP = RP1 * RP2 + IP1 * IP2 * -1; // (a + bi) * (c + di) = ac + adi + bci + bdii (bdii = bd * -1)
         double newIP = RP1 * IP2 + IP1 * RP2;
         return new complexNumber(newRP, newIP);
      }

      public complexNumber oppositeNumber()
      {
         return new complexNumber(-this.realPart, -this.imaginaryPart);
      }

      public complexNumber complexConjugatedNumber()
      {
         return new complexNumber(this.realPart, -this.imaginaryPart);
      }

      public double absoluteValue()
      {
         double realQuadrat = Math.Pow(this.realPart, 2);
         double imaginaryQuadrat = Math.Pow(this.imaginaryPart, 2);
         return Math.Sqrt(realQuadrat + imaginaryQuadrat);
      }

      public double radToDeg(double rad)
      {
         return 180 / Math.PI * rad;
      }

      public double argument()
      {
         double RP = this.realPart;
         double IP = this.imaginaryPart;
         int quadrant;
         double arg, tgPhi;
         if (RP != 0)
            tgPhi = IP / RP;
         else if (IP > 0)
            return 90;
         else if (IP < 0)
            return 270;
         else
            return 0;

         if (RP > 0 && IP > 0)
            quadrant = 1;
         else if (RP < 0 && IP > 0)
            quadrant = 2;
         else if (RP < 0 && IP < 0)
            quadrant = 3;
         else
            quadrant = 4;

         switch (quadrant)
         {
            case 1:
               return radToDeg(Math.Atan(tgPhi));
            case 2:
               return 180.0 + radToDeg( Math.Atan(tgPhi));
            case 3:
               return 180.0 + radToDeg(Math.Atan(tgPhi));
            default:
               return 360.0 + radToDeg(Math.Atan(tgPhi));
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         complexNumber cnum1 = new complexNumber(1, 3);
         complexNumber cnum2 = new complexNumber(-2, 2);
         complexNumber addition = cnum1.addComplexNumber(cnum2);
         complexNumber multiplication = cnum1.multiplyWithComplexNumber(cnum2);
         complexNumber opposite = cnum1.oppositeNumber();
         complexNumber conjugated = cnum1.complexConjugatedNumber();
         double absval = cnum1.absoluteValue();
         double arg = cnum1.argument();
         Console.WriteLine("Addition: Re = " + addition.realPart + ", Im = " + addition.imaginaryPart);
         Console.WriteLine("Multiplication: Re = " + multiplication.realPart + ", Im = " + multiplication.imaginaryPart);
         Console.WriteLine("Opposite to the first number: Re = " + opposite.realPart + ", Im = " + opposite.imaginaryPart);
         Console.WriteLine("Complex conjugated to the first number: Re = " + conjugated.realPart + ", Im = " + conjugated.imaginaryPart);
         Console.WriteLine("Absolute value of the first number: " + absval);
         Console.WriteLine("Argument of the first number: " + arg + " deg");
         Console.ReadLine();
         return;
      }
   }
}
