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
int main(int argc, char *argv[])
{
	int sockfd, newsockfd, portno,a,op,opr;
        //float c,d ;
	socklen_t clilen;
	char buffer[256];
	struct	sockaddr_in serv_addr, cli_addr;
	int n;
        int n1,data_1,data_2,ans;
	if(argc<2)
	{
		fprintf(stderr, "ERROR, no port provided\n");
		exit(1);
	}
	sockfd = socket(AF_INET, SOCK_STREAM,0);
	if(sockfd<0)
		error("ERROR opening socket");
	bzero((char *)&serv_addr, sizeof(serv_addr));
	portno=atoi(argv[1]);
	serv_addr.sin_family = AF_INET;
	serv_addr.sin_addr.s_addr = INADDR_ANY;
	serv_addr.sin_port = htons(portno);
	if(bind(sockfd, (struct sockaddr *) &serv_addr, sizeof(serv_addr))<0)
	error("ERROR on binding");
	listen(sockfd,5);
	clilen = sizeof(cli_addr);
	newsockfd = accept(sockfd, (struct sockaddr *) &cli_addr, &clilen);
	if(newsockfd<0)
	error("ERROR on accept");



	bzero(buffer, 256);
	n=read(newsockfd,buffer,255);
        data_1=atoi(buffer);

	if(n<0)
	error("ERROR reading from socket");
        //printf("Here is the message: %s\n",buffer);




        bzero(buffer, 256);
	n1=read(newsockfd,buffer,255);
        data_2=atoi(buffer);

	if(n1<0)
	error("ERROR reading from socket");
	//printf("Here is the message: %s\n",buffer);



        ans=data_1 + data_2 ;
        printf("server ans is = %d",ans);

        sprintf(buffer,"%d",ans);
        n= write(newsockfd,buffer,255);

////////////////////////////////

        bzero(buffer, 256);
	op=read(newsockfd,buffer,255);
        opr=atoi(buffer);

	if(op<0)
	error("ERROR reading from socket");

       
   
        
        if(opr==1)
        {
          a=data_1+data_2;
          printf("the client addition is = %d\n",a);

        }

 
        else if(opr==2)
        {
          a=data_1-data_2;
          printf("the client subtraction is = %d\n",a);

        }

        else if (opr==3)
        {
          a=data_1*data_2;
          printf("the client multiplication is = %d\n",a);

        }

        else if (opr==4)
        {
           a=data_1/data_2;
          printf("the client division is = %d\n",a);

        }







////////////////////////



       


	//n= write(newsockfd,"%d\n",ans);
        
	if(n<0)
	error("ERROR writing to socket");
	close(newsockfd);
	close(sockfd);
	return 0;
}
