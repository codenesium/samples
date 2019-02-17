import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';

interface Props {
    model?:VoteViewModel
}

   const VoteCreateDisplay: React.SFC<FormikProps<VoteViewModel>> = (props: FormikProps<VoteViewModel>) => {

   let status = props.status as CreateResponse<Api.VoteClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof VoteViewModel]  && props.errors[name as keyof VoteViewModel]) {
            response += props.errors[name as keyof VoteViewModel];
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
                        <label htmlFor="name" className={errorExistForField("bountyAmount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BountyAmount</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="bountyAmount" className={errorExistForField("bountyAmount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("bountyAmount") && <small className="text-danger">{errorsForField("bountyAmount")}</small>}
                        </div>
                    </div>

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
                        <label htmlFor="name" className={errorExistForField("userId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UserId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="userId" className={errorExistForField("userId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("userId") && <small className="text-danger">{errorsForField("userId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("voteTypeId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>VoteTypeId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="voteTypeId" className={errorExistForField("voteTypeId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("voteTypeId") && <small className="text-danger">{errorsForField("voteTypeId")}</small>}
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


const VoteCreate = withFormik<Props, VoteViewModel>({
    mapPropsToValues: props => {
                
		let response = new VoteViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.bountyAmount,props.model!.creationDate,props.model!.id,props.model!.postId,props.model!.userId,props.model!.voteTypeId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<VoteViewModel> = { };

	  if(values.creationDate == undefined) {
                errors.creationDate = "Required"
                    }if(values.postId == 0) {
                errors.postId = "Required"
                    }if(values.voteTypeId == 0) {
                errors.voteTypeId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new VoteMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Votes,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.VoteClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'VoteCreate', 
  })(VoteCreateDisplay);

  interface VoteCreateComponentProps
  {
  }

  interface VoteCreateComponentState
  {
      model?:VoteViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class VoteCreateComponent extends React.Component<VoteCreateComponentProps, VoteCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<VoteCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>72ec9dfae69c4e10b47cdbb358b67771</Hash>
</Codenesium>*/