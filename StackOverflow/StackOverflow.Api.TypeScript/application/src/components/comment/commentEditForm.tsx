import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CommentViewModel from './commentViewModel';
import CommentMapper from './commentMapper';

interface Props {
    model?:CommentViewModel
}

  const CommentEditDisplay = (props: FormikProps<CommentViewModel>) => {

   let status = props.status as UpdateResponse<Api.CommentClientRequestModel>;
   
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creationDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreationDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="creationDate" className={errorExistForField("creationDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creationDate") && <small className="text-danger">{errorsForField("creationDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("postId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PostId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="postId" className={errorExistForField("postId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("postId") && <small className="text-danger">{errorsForField("postId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("score") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Score</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="score" className={errorExistForField("score") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("score") && <small className="text-danger">{errorsForField("score")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("text") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Text</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="text" className={errorExistForField("text") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("text") && <small className="text-danger">{errorsForField("text")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("userId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UserId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="userId" className={errorExistForField("userId") ? "form-control is-invalid" : "form-control"} />
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
          </form>
  );
}


const CommentEdit = withFormik<Props, CommentViewModel>({
    mapPropsToValues: props => {
        let response = new CommentViewModel();
		response.setProperties(props.model!.creationDate,props.model!.id,props.model!.postId,props.model!.score,props.model!.text,props.model!.userId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<CommentViewModel> = { };

	  if(values.creationDate == undefined) {
                errors.creationDate = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
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

        axios.put(Constants.ApiEndpoint + ApiRoutes.Comments +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.CommentClientRequestModel>;
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
  
    displayName: 'CommentEdit', 
  })(CommentEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface CommentEditComponentProps
  {
     match:IMatch;
  }

  interface CommentEditComponentState
  {
      model?:CommentViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CommentEditComponent extends React.Component<CommentEditComponentProps, CommentEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Comments + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CommentClientResponseModel;
            
            console.log(response);

			let mapper = new CommentMapper();

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
            return (<CommentEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a9ebd26338175d2a69626fd13105f6bf</Hash>
</Codenesium>*/