import scala.concurrent.Future
import scala.language.implicitConversions
import scala.util.chaining._
import scala.util.ChainingOps



class ScalaCode {


  def plus1(i: Int) = i + 1

  def double(i: Int) = i * 2

  def square(i: Int) = i * i

  def pipe(i:Int) = {
    val x = i.pipe(plus1).pipe(double).pipe(square)
    println(s"x = $x")
  }

  sealed trait Shape
  case class Rect(x: Double, y: Double) extends Shape
  case class Circle(r: Double) extends Shape


  def perimetr(p: Shape) = p match {
    case Rect(x, y) => x+y
    case Circle(r) => 2*r*math.Pi
  }


  def per(): Unit ={
    println(perimetr(Rect(1,2)));
    println(perimetr(Circle(4)));
  }

  def main(args: Array[String]): Unit = {

  }
}
