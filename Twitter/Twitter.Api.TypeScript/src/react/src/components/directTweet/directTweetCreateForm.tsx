import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import DirectTweetMapper from './directTweetMapper';
import DirectTweetViewModel from './directTweetViewModel';

interface Props {
    model?:DirectTweetViewModel
}

   const DirectTweetCreateDisplay: React.SFC<FormikProps<DirectTweetViewModel>> = (props: FormikProps<DirectTweetViewModel>) => {

   let status = props.status as CreateResponse<Api.DirectTweetClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof DirectTweetViewModel]  && props.errors[name as keyof DirectTweetViewModel]) {
            response += props.errors[name as keyof DirectTweetViewModel];
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

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("content") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Content</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="content" className={errorExistForField("content") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("content") && <small className="text-danger">{errorsForField("content")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("date") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Date</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="date" className={errorExistForField("date") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("date") && <small className="text-danger">{errorsForField("date")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("taggedUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Tagged_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="taggedUserId" className={errorExistForField("taggedUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("taggedUserId") && <small className="text-danger">{errorsForField("taggedUserId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("time") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Time</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="time" className={errorExistForField("time") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("time") && <small className="text-danger">{errorsForField("time")}</small>}
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
          </form>);
}


const DirectTweetCreate = withFormik<Props, DirectTweetViewModel>({
    mapPropsToValues: props => {
                
		let response = new DirectTweetViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.content,props.model!.date,props.model!.taggedUserId,props.model!.time,props.model!.tweetId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<DirectTweetViewModel> = { };

	  if(values.content == '') {
                errors.content = "Required"
                    }if(values.date == undefined) {
                errors.date = "Required"
                    }if(values.taggedUserId == 0) {
                errors.taggedUserId = "Required"
                    }if(values.time == undefined) {
                errors.time = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new DirectTweetMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.DirectTweets,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.DirectTweetClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'DirectTweetCreate', 
  })(DirectTweetCreateDisplay);

  interface DirectTweetCreateComponentProps
  {
  }

  interface DirectTweetCreateComponentState
  {
      model?:DirectTweetViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class DirectTweetCreateComponent extends React.Component<DirectTweetCreateComponentProps, DirectTweetCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<DirectTweetCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>3fc1dfcf67c9092942787cf34e5182c4</Hash>
</Codenesium>*/