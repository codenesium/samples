import * as React from 'react'

interface ErrorFormProps
{
    message:string;
}
export const ErrorForm: React.SFC<ErrorFormProps> = (props) => {
   return <div className="alert alert-danger">{props.message}</div>;
}