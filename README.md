# CodeCommit2Slack
This project is an AWS Lambda handler that forwards Code Commit events to a Slack Channel. It provides more 
detail than the standard email subscriber and of course sinces you have the source code
you cna modify it to do anything you want. Compiling and publshing this project requires
that you have the AWS Lambda toolkit for .NET installed. Assuming you are using the 
project code "as is" then the following steps will install it.

*  Compile and package the prjoect with the command dotnet lambda package --configuration "Lambda-Debug" 
*  Create a slack channel for your account https://slack.com/help/articles/115005265063-Incoming-WebHooks-for-Slack
, enable web hooks and collect the url with the embedded token, you can also set the logo for your channel 
*  Use the AWS wizard to create a Lambda https://docs.aws.amazon.com/codecommit/latest/userguide/how-to-notify-lambda.html and upload the code package
*  Make sure it triggers for new branch, branch delete and push.
*  On the Lambda, modify the envionrment variable SlackChannelUrl so that it is set to the url with the embeded token
*  Optionally set the Lambda environment variable MaxChangesWarningThreshold to represent the maximum changes before the notification becomes a warning
*  Make sure your Lambda role has CodeCommit readonly access. 
*  Setup pull notifications for the CodeCommit repository, then edit the notification to remove the SNS and change it to notify the same Lambda

Coming soon: step by step setup guide

