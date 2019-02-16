import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import IncludedColumnTestViewModel from './includedColumnTestViewModel';
import IncludedColumnTestMapper from './includedColumnTestMapper';

interface Props {
    model?:IncludedColumnTestViewModel
}

  const IncludedColumnTestEditDisplay = (props: FormikProps<IncludedColumnTestViewModel>) => {

   let status = props.status as UpdateResponse<Api.IncludedColumnTestClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof IncludedColumnTestViewModel]  && props.errors[name as keyof IncludedColumnTestViewModel]) {
            response += props.errors[name as keyof IncludedColumnTestViewModel];
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
                        <label htmlFor="name" className={errorExistForField("name2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name2</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name2" className={errorExistForField("name2") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name2") && <small className="text-danger">{errorsForField("name2")}</small>}
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


const IncludedColumnTestEdit = withFormik<Props, IncludedColumnTestViewModel>({
    mapPropsToValues: props => {
        let response = new IncludedColumnTestViewModel();
		response.setProperties(props.model!.id,props.model!.name,props.model!.name2);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<IncludedColumnTestViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.name2 == '') {
                errors.name2 = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new IncludedColumnTestMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.IncludedColumnTests +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.IncludedColumnTestClientRequestModel>;
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
  
    displayName: 'IncludedColumnTestEdit', 
  })(IncludedColumnTestEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface IncludedColumnTestEditComponentProps
  {
     match:IMatch;
  }

  interface IncludedColumnTestEditComponentState
  {
      model?:IncludedColumnTestViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class IncludedColumnTestEditComponent extends React.Component<IncludedColumnTestEditComponentProps, IncludedColumnTestEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.IncludedColumnTests + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.IncludedColumnTestClientResponseModel;
            
            console.log(response);

			let mapper = new IncludedColumnTestMapper();

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
            return (<IncludedColumnTestEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>584e01abf3ee4f8afaadef3f15355289</Hash>
</Codenesium>*/