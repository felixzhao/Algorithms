#include <stdio.h>

int Min_2(int a, int b)
{
	return a > b? b : a;
}

int Minimum(int a, int b, int c)
{
	int min = Min_2(a,b);
	return Min_2(min, c);
}

int Minimum_Edit_Distance(char * A, int m, char * B, int n)
{
	int metrix[10][10];
	
	// init
	for (int i = 0; i < m; i++) {
		metrix[i][0] = i;
	}
	for (int j = 1; j < n; j++) {
		metrix[0][j] = j;
	}
	
	for (int i = 1; i < m; i++) {
		for (int j = 1; j < n; j++) {
			int z = 1;
			if(A[i] == B[j])
				z = 0;
			metrix[i][j] =
				Minimum(
						metrix[i-1][j] + 1,
						metrix[i][j-1] + 1,
						metrix[i-1][j-1] + z);
			printf("%d,%d:\n",i,j);
			printf("metrix[i-1][j] + 1 : %d,%d = %d\n",i-1,j,metrix[i-1][j] + 1);
			printf("metrix[i][j-1] + 1 : %d,%d = %d\n",i,j-1,metrix[i][j-1] + 1);
			printf("metrix[i-1][j-1] + z : %d,%d,%d = %d\n",i-1,j-1,z,metrix[i-1][j-1] + z);			
			printf("Metrix[%d][%d] = %d\n",i,j,metrix[i][j]);
			printf("\n");
		}
	}

	printf("result = %d\n",metrix[m-1][n-1]);
	return metrix[m-1][n-1];
	
}

int Min_Edit_Distance(char * A, int m, char * B, int n)
{
	return 0;
}

int main (int argc, const char * argv[]) {
	char * A = "abc";
	char * B = "afec";
	
	int n = 1;
	
	n = Minimum_Edit_Distance(A, 3, B, 4);
	
	printf("min = %d",n);
		
    return 0;
}
