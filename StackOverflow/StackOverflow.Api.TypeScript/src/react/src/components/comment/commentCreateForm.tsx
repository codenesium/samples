import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CommentMapper from './commentMapper';
import CommentViewModel from './commentViewModel';

interface Props {
    model?:CommentViewModel
}

   const CommentCreateDisplay: React.SFC<FormikProps<CommentViewModel>> = (props: FormikProps<CommentViewModel>) => {

   let status = props.status as CreateResponse<Api.CommentClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof CommentViewModel]  && props.errors[name as keyof CommentViewModel]) {
            response += props.errors[name as keyof CommentViewModel];
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
                        <label htmlFor="name" className={errorExistForField("creationDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreationDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="creationDate" className={errorExistForField("creationDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creationDate") && <small className="text-danger">{errorsForField("creationDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("postId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PostId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="postId" className={errorExistForField("postId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("postId") && <small className="text-danger">{errorsForField("postId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("score") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Score</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="score" className={errorExistForField("score") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("score") && <small className="text-danger">{errorsForField("score")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("text") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Text</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="text" className={errorExistForField("text") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("text") && <small className="text-danger">{errorsForField("text")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("userId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UserId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="userId" className={errorExistForField("userId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("userId") && <small className="text-danger">{errorsForField("userId")}</small>}
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


const CommentCreate = withFormik<Props, CommentViewModel>({
    mapPropsToValues: props => {
                
		let response = new CommentViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.creationDate,props.model!.id,props.model!.postId,props.model!.score,props.model!.text,props.model!.userId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<CommentViewModel> = { };

	  if(values.creationDate == undefined) {
                errors.creationDate = "Required"
                    }if(values.postId == 0) {
                errors.postId = "Required"
                    }if(values.text == '') {
                errors.text = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new CommentMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Comments,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.CommentClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'CommentCreate', 
  })(CommentCreateDisplay);

  interface CommentCreateComponentProps
  {
  }

  interface CommentCreateComponentState
  {
      model?:CommentViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CommentCreateComponent extends React.Component<CommentCreateComponentProps, CommentCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<CommentCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>17000550099003df9ae31ce2932791f7</Hash>
</Codenesium>*/