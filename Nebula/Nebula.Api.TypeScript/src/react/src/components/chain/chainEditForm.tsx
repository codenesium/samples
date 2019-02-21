import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ChainViewModel from './chainViewModel';
import ChainMapper from './chainMapper';

interface Props {
    model?:ChainViewModel
}

  const ChainEditDisplay = (props: FormikProps<ChainViewModel>) => {

   let status = props.status as UpdateResponse<Api.ChainClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ChainViewModel]  && props.errors[name as keyof ChainViewModel]) {
            response += props.errors[name as keyof ChainViewModel];
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
                        <label htmlFor="name" className={errorExistForField("chainStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ChainStatusId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="chainStatusId" className={errorExistForField("chainStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("chainStatusId") && <small className="text-danger">{errorsForField("chainStatusId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("externalId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExternalId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="externalId" className={errorExistForField("externalId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("externalId") && <small className="text-danger">{errorsForField("externalId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("teamId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TeamId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="teamId" className={errorExistForField("teamId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("teamId") && <small className="text-danger">{errorsForField("teamId")}</small>}
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


const ChainEdit = withFormik<Props, ChainViewModel>({
    mapPropsToValues: props => {
        let response = new ChainViewModel();
		response.setProperties(props.model!.chainStatusId,props.model!.externalId,props.model!.id,props.model!.name,props.model!.teamId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ChainViewModel> = { };

	  if(values.chainStatusId == 0) {
                errors.chainStatusId = "Required"
                    }if(values.externalId == undefined) {
                errors.externalId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.teamId == 0) {
                errors.teamId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ChainMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Chains +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ChainClientRequestModel>;
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
  
    displayName: 'ChainEdit', 
  })(ChainEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ChainEditComponentProps
  {
     match:IMatch;
  }

  interface ChainEditComponentState
  {
      model?:ChainViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ChainEditComponent extends React.Component<ChainEditComponentProps, ChainEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Chains + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ChainClientResponseModel;
            
            console.log(response);

			let mapper = new ChainMapper();

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
            return (<ChainEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>aa67ccab97e921eefb0da74e3f51d779</Hash>
</Codenesium>*/