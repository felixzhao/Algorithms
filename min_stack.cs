public class MinStack<T>
{
  private int top, max_size, min_top;
  private IList<T> stack,min_stack;

  public MinStack(int max)
  {
    max_size = max;
    top = -1;
    min_top = -1;
    stack = new List<T>(max);
    min_stack = new List<T>(max);
  }

  public T POP()
  {
    if(top == -1)
      {
	return null;
      }

    if(stack[top] != min_stack[min_top])
      {
	min_top--;
      }
    return stack[top--];
  }

  public void PUSH(T item)
  {
    if(top == max)
      {
	return;
      }
    if(item < min_stack[min_top])
      {
	min_stack.Add(item);
	min_top++;
      }
    stack.Add(item);
    top++;
  }

  public T MIN()
  {
    if(min_top == -1)
      return null;
    return min_stack[min_top];
  }
}
