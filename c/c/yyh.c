#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <memory.h>
# define SIZE 3

struct data{
	char name[100];
	int number;
	char callnumber[100];
	char address[100];
	int a[6];
	double sales;
	int max[3];
	int min[3];
};
struct data s[100];
int cnt = 0;
void option1() {
	int i;
	for (i = 0; i < SIZE; i++) {
		printf("매장의 이름 : ");
		scanf(" %s", s[i].name);
		printf("매장 시리얼 넘버 : ");
		scanf(" %d", &s[i].number);
		printf("매장 주소 : ");
		scanf(" %s", s[i].address);
		printf("매장 전화번호 : ");
		scanf(" %s", s[i].callnumber);
		for (int j = 0; j < 6; j++) {
			printf("%d 월의 매출액 : ", j + 1);
			scanf("%d", &s[i].a[j]);
		}
	}
	
}
void maxmin() {
	int i, k;
	double Min = s[0].sales;

	for (i = 0; i < SIZE; i++) {
		double Min = s[i].sales;
		if (s[i].number != 0) {
			s[i].sales = ((double)s[i].a[0] + s[i].a[1] + s[i].a[2] + s[i].a[3] + s[i].a[4] + s[i].a[5]);
		}
		for (i = 0; i < SIZE; i++) {
			if (Min > s[i].sales) {
				Min = s[i].sales;
			}
		}
		double Max = s[0].sales;
		for (i = 0; i < SIZE; i++) {
			if (Max < s[i].sales) {
				Max = s[i].sales;
			}
		}
	}
}
void option2() {
	int i;
	for (i = 0; i < SIZE; i++) {
		if (s[i].number != 0) {
			s[i].sales = ((double)s[i].a[0] + s[i].a[1] + s[i].a[2] + s[i].a[3] + s[i].a[4] + s[i].a[5]);
			printf("매장이름 = %s 시리얼넘버 = %d 매장의 주소 = %s 전화번호 = %s \n1월매출액 = %d 2월매출액 = %d 3월매출액 = %d 4월매출액 = %d 5월매출액 = %d 6월매출액 = %d \n총 매출액 = %.3lf \n"
				, s[i].name, s[i].number, s[i].address, s[i].callnumber, s[i].a[0], s[i].a[1], s[i].a[2], s[i].a[3], s[i].a[4], s[i].a[5], s[i].sales);
		}
		else
			printf("입력이 안 되어있습니다. \n");
	}
}
void option3() {
	int i;
	char a[100];
	printf("매장의 이름을 입력하세요 : ");
	scanf("%s", a);
	for (i = 0; i < SIZE; i++) {
		if (strcmp(s[i].name, a) == 0) {
			printf("매장이름 = %s 시리얼넘버 = %d 매장의 주소 = %s 전화번호 = %s 1월매출액 = %d 2월매출액 = %d 3월매출액 = %d 4월매출액 = %d 5월매출액 = %d 6월매출액 = %d 총 매출액 = %.3lf\n"
				, s[i].name, s[i].number, s[i].address, s[i].callnumber, s[i].a[0], s[i].a[1], s[i].a[2], s[i].a[3], s[i].a[4], s[i].a[5], s[i].sales);
		}
	}
}
void option4() {
	int i, n;
	printf("매장의 시리얼 넘버를 입력하세요 : ");
	scanf_s("%d", &n);
	for (i = 0; i < SIZE; i++) {
		if (s[i].number == n) {
			printf("매장이름 = %s 시리얼넘버 = %d 매장의 주소 = %s 전화번호 = %s 1월매출액 = %d 2월매출액 = %d 3월매출액 = %d 4월매출액 = %d 5월매출액 = %d 6월매출액 = %d 총 매출액 = %.3lf\n"
				, s[i].name, s[i].number, s[i].address, s[i].callnumber, s[i].a[0], s[i].a[1], s[i].a[2], s[i].a[3], s[i].a[4], s[i].a[5], s[i].sales);
		}
	}
}

void option5() {
	maxmin();
	int index;
	struct data temp;
	int i, k;
	for (i = 0; i < SIZE - 1; i++) {
		index = i;
		for (k = i + 1; k < SIZE; k++) {
			if (s[k].sales < s[index].sales) {
				index = k;
			}
		}
		temp = s[index];
		s[index] = s[i];
		s[i] = temp;
	}
		printf("매출액이 가장 높은 매장 이름 = %s 전화번호 = %s 총 매출액 = %.3lf\n", s[i].name, s[i].callnumber, s[i].sales);

}
void option6() {
	char snumber[300];
	int i;
	int max = SIZE;
	printf("삭제하실 시리얼 넘버를 입력하세요 : ");
	scanf_s("%d", &snumber);
	for (i = 0; i < max; i++) {
		if (snumber == s[i].number) {
			printf("올바른 시리얼 넘버(%d)입니다. ", snumber);
			break;
		}
	}
	if (i == max) {
		printf("시리얼 넘버(%d)가 없습니다 .", snumber);
		return 0;
	}
	for (int j = i; i < max; j++) {
		s[j] = s[j + 1];
	}
	--max;
	printf("시리얼 넘버(%d)의 데이터를 삭제했습니다 \n", snumber);
}
void option7() {
	int i, k;
	printf("변경할 시리얼 번호를 입력하세요 : ");
	scanf_s("%d", &k);
	for (i = 0; i < SIZE; i++) {
		if (s[i].number == k) {
			printf("매장의 이름 : ");
			scanf(" %s", s[i].name);
			printf("매장 시리얼 넘버 : ");
			scanf(" %d", &s[i].number);
			printf("매장 주소 : ");
			scanf(" %s", s[i].address);
			printf("매장 전화번호 : ");
			scanf(" %s", s[i].callnumber);
			for (int j = 0; j < 6; j++) {
				printf("%d 월의 매출액 : ", j + 1);
				scanf("%d", &s[i].a[j]);
			}
		}
	}
}
void option8() {
	FILE* fp;
	int number;
	int k,j;
	fp = fopen("C:\/Users/82108/newfile/test.txt", "w");
	printf("저장할 데이터의 시리얼 넘버를 입력하세요 : ");
	scanf_s("%d", &k);
	for (j = 0; j < SIZE; j++) {
		if (s[j].number == k) {
			fprintf(fp, "매장의 이름 = %s 매장 시리얼 넘버 = %d 매장 주소 = %s 매장 전화번호 = %s 1월 매출액 = %d 2월 매출액 = %d 3월 매출액 = %d 4월 매출액 = %d 5월 매출액 = %d 6월 매출액 = %d", s[j].name, s[j].number, s[j].address, s[j].callnumber, s[j].a[0], s[j].a[1], s[j].a[2], s[j].a[3], s[j].a[4], s[j].a[5]);
			fclose(fp);
			printf(" 저장에 성공했습니다. \n");
		}
		else if (s[j].number !=k) {
			printf(" 저장에 실패했습니다. \n");
			//exit(1);
		}
	}
}
void option9() {
	FILE* fp;
	fp = fopen("C:\/Users/82108/newfile/test.txt", "r");
	char buffer[1000] = { 0, };
	fread(buffer,1,1000,fp);
	printf("%s\n", buffer);

	fclose(fp);
}
void menu() {
	printf("메뉴를 선택하세요 \n");
	printf("1. 데이터 입력\n");
	printf("2. 입력한 모든 정보 출력\n");
	printf("3. 매장 이름으로 검색하기\n");
	printf("4. 매장의 시리얼 넘버로 검색하기\n");
	printf("5. 총 매출액이 가장 높은 매장 이름과 전화번호, 매출액 출력\n");
	printf("6. 시리얼 번호로 정보 삭제하기\n");
	printf("7. 시리얼 번호로 정보 변경하기\n");
	printf("8. 파일로 저장하기\n");
	printf("9. 파일에서 읽어오기\n");
	printf("'q' 또는 'Q' 입력시 종료\n");
}
int main(void) {
	char c;
	int p = 0;
	menu();
	while (1) {
		printf("메뉴 입력 : ");
		c = getchar();
		if (c == 'q' || c == 'Q') {
			printf("프로그램을 종료 합니다 ");
			break;
		}
		else if (c == '1')
			option1();
		else if (c == '2')
			option2();
		else if (c == '3')
			option3();
		else if (c == '4')
			option4();
		else if (c == '5')
			option5();
		else if (c == '6')
			option6();
		else if (c == '7')
			option7();
		else if (c == '8')
			option8();
		else if (c == '9')
			option9();
		getchar();
	}
}