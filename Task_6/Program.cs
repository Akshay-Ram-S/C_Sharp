using System;

public delegate void ThresholdReachedHandler(object sender, EventArgs e); // Delegate Definition

public class Counter{
  int count = 0, threshold = 0;
  public event ThresholdReachedHandler? ThresholdReached; // Event Declaration
  public Counter(int threshold_value){
    threshold = threshold_value;
  }
  public void Increment(){
    count++;
    Console.WriteLine("Current Count : " + count);
    if(count >= threshold){
      OnThresholdReached(EventArgs.Empty);
      count = 0;
    }
  }
  // Event Raiser
  protected virtual void OnThresholdReached(EventArgs e){
    ThresholdReached?.Invoke(this,e);
  }
}

class Program{
  // Event Handler 1
  static void EventHandler1(object sender, EventArgs e){
    Console.WriteLine("Threshold Reached - From EventHandler1");
  }
  // Event Handler 2
  static void EventHandler2(object sender, EventArgs e){
    Console.WriteLine("Threshold Reached - From EventHandler2");
  }

  static void Main(){
    Counter ctr = new Counter(5);
    ctr.ThresholdReached += EventHandler1; // Subscribing EventHandler1 to the event
    ctr.ThresholdReached += EventHandler2; // Subscribing EventHandler2 to the event
    for(int i=0; i <= 20; i++){
      ctr.Increment();
      System.Threading.Thread.Sleep(1000); // Slows down the output
    }
  }
}
