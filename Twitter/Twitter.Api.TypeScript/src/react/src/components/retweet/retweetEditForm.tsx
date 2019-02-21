import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import RetweetViewModel from './retweetViewModel';
import RetweetMapper from './retweetMapper';

interface Props {
    model?:RetweetViewModel
}

  const RetweetEditDisplay = (props: FormikProps<RetweetViewModel>) => {

   let status = props.status as UpdateResponse<Api.RetweetClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof RetweetViewModel]  && props.errors[name as keyof RetweetViewModel]) {
            response += props.errors[name as keyof RetweetViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("date") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Date</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="date" className={errorExistForField("date") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("date") && <small className="text-danger">{errorsForField("date")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("retwitterUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Retwitter_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="retwitterUserId" className={errorExistForField("retwitterUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("retwitterUserId") && <small className="text-danger">{errorsForField("retwitterUserId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("time") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Time</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="time" className={errorExistForField("time") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("time") && <small className="text-danger">{errorsForField("time")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("tweetTweetId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Tweet_tweet_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="tweetTweetId" className={errorExistForField("tweetTweetId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("tweetTweetId") && <small className="text-danger">{errorsForField("tweetTweetId")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const RetweetEdit = withFormik<Props, RetweetViewModel>({
    mapPropsToValues: props => {
        let response = new RetweetViewModel();
		response.setProperties(props.model!.date,props.model!.id,props.model!.retwitterUserId,props.model!.time,props.model!.tweetTweetId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<RetweetViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.tweetTweetId == 0) {
                errors.tweetTweetId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new RetweetMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Retweets +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.RetweetClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'RetweetEdit', 
  })(RetweetEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface RetweetEditComponentProps
  {
     match:IMatch;
  }

  interface RetweetEditComponentState
  {
      model?:RetweetViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class RetweetEditComponent extends React.Component<RetweetEditComponentProps, RetweetEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Retweets + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.RetweetClientResponseModel;
            
            console.log(response);

			let mapper = new RetweetMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<RetweetEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>825b01e138141943105393c27eb58876</Hash>
</Codenesium>*/