#include <stdio.h>

int findbigger(int *list, int length)
{
	if (length <= 1) {
		return -1;
	}
	
	int max= 0, bigger = -1;
	
	int i = 1;
	for (; i < length; i++) {
		if (list[i] > list[max]) {
			break;
		}
	}
	
	//fix bug for {2,1}
	if (i == length && list[length - 1] < list[max]) {
		bigger = list[length - 1];
	}
	
	for (int j = i; j < length; j++) {
		if (list[j] > list[max]) {
			bigger = max;
			max = j;
		}
		else if(bigger == -1)
			bigger = j;
		else if(list[j] > list[bigger])
			bigger = j;
	}
	
	return bigger;
}

int main (int argc, const char * argv[]) {
    // insert code here...
    printf("Hello, World!\n");
	
	int array[3] = { 1,2,3};
	
	int bigger = findbigger(array, 3);
	
	printf("Bigger is : %d\n",array[bigger]);
	
	//
	
    int	array1[3] = { 1,1,1};
	
	bigger = findbigger(array1, 3);
	
	if (bigger == -1) {
		printf("Bigger not existed.\n");
	}
	else {
		printf("Bigger is : %d\n",array1[bigger]);
		
	}
	
	//
	
    int	array2[2] = { 2,1};
	
	bigger = findbigger(array2, 2);
	
	if (bigger == -1) {
		printf("Bigger not existed.\n");
	}
	else {
		printf("Bigger is : %d\n",array2[bigger]);
		
	}
	
	//
	
    int	array3[3] = { 1,1,2};
	
	bigger = findbigger(array3, 3);
	
	if (bigger == -1) {
		printf("Bigger not existed.\n");
	}
	else {
		printf("Bigger is : %d\n",array3[bigger]);
		
	}

	    return 0;
}
