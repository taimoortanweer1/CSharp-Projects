
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>


void error(const char *msg)
{
	perror(msg);
	exit(0);
}

int main(int argc, const char *argv[])
{
	int sockfd,portno,n,n1,n3,n4,n2;
  

	struct sockaddr_in serv_addr;
	struct hostent *server;
	char buffer[256];
	if(argc<3)
	{
		fprintf(stderr, "usage %s hostname port\n",argv[0]);
		exit(0);
	}
	portno = atoi(argv[2]);
	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if(sockfd<0)
		error("ERROR opening socket");
	server = gethostbyname(argv[1]);
	if(server == NULL)
	{
		fprintf(stderr, "ERROR, no such host\n");
		exit(0);
	}
	bzero((char *)&serv_addr, sizeof(serv_addr));
	serv_addr.sin_family = AF_INET;
	bcopy((char *)server->h_addr, (char *)&serv_addr.sin_addr.s_addr,server->h_length);
	serv_addr.sin_port = htons(portno);
	if(connect(sockfd,(struct sockaddr *) &serv_addr, sizeof(serv_addr))<0)
		error("ERROR connecting");

	printf("Please enter first number: ");
	bzero(buffer,256);
	fgets(buffer,255,stdin);
	n= write(sockfd,buffer,strlen(buffer));
	if(n<0)
		error("ERROR writing to socket");
	


	printf("Please enter second number: ");
	bzero(buffer,256);
	fgets(buffer,255,stdin);
	n1= write(sockfd,buffer,strlen(buffer));
	if(n1<0)
	error("ERROR writing to socket");
	//n = read(sockfd,buffer,255);



////////////////////////////////////////
        printf("1 is for add\n");
        printf("2 is for subtract\n");
        printf("3 is for multiply\n");
        printf("4 is for division\n");
        printf("\nPlease enter the eperation : \n");

	bzero(buffer,256);
	fgets(buffer,255,stdin);
	n2= write(sockfd,buffer,strlen(buffer));
	if(n2<0)
	error("ERROR writing to socket");
	//n = read(sockfd,buffer,255);

       

     
      


////////////////////////////////////






       bzero(buffer,256);
       n3=read(sockfd,buffer,255);
       n4=atoi(buffer);

       if(n3<0)
	error("ERROR writing to socket");
       printf("sum of client is = %d\n" , n4);





         //n= write(sockfd,buffer,strlen(buffer));
        
        



	//if(n<0)
	//error("ERROR reading from the socket");
	//printf("%s\n",buffer);
	//close(sockfd);


	//if(n1<0)
	//error("ERROR reading from the socket");
	//printf("%s\n",buffer);
	close(sockfd);

	return 0;
}	
