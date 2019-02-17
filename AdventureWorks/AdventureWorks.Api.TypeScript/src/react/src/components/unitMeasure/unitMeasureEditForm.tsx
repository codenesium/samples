import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import UnitMeasureViewModel from './unitMeasureViewModel';
import UnitMeasureMapper from './unitMeasureMapper';

interface Props {
    model?:UnitMeasureViewModel
}

  const UnitMeasureEditDisplay = (props: FormikProps<UnitMeasureViewModel>) => {

   let status = props.status as UpdateResponse<Api.UnitMeasureClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof UnitMeasureViewModel]  && props.errors[name as keyof UnitMeasureViewModel]) {
            response += props.errors[name as keyof UnitMeasureViewModel];
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
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("unitMeasureCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UnitMeasureCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="unitMeasureCode" className={errorExistForField("unitMeasureCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("unitMeasureCode") && <small className="text-danger">{errorsForField("unitMeasureCode")}</small>}
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


const UnitMeasureEdit = withFormik<Props, UnitMeasureViewModel>({
    mapPropsToValues: props => {
        let response = new UnitMeasureViewModel();
		response.setProperties(props.model!.modifiedDate,props.model!.name,props.model!.unitMeasureCode);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<UnitMeasureViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.unitMeasureCode == '') {
                errors.unitMeasureCode = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new UnitMeasureMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.UnitMeasures +'/' + values.unitMeasureCode,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.UnitMeasureClientRequestModel>;
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
  
    displayName: 'UnitMeasureEdit', 
  })(UnitMeasureEditDisplay);

 
  interface IParams 
  {
     unitMeasureCode:string;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface UnitMeasureEditComponentProps
  {
     match:IMatch;
  }

  interface UnitMeasureEditComponentState
  {
      model?:UnitMeasureViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class UnitMeasureEditComponent extends React.Component<UnitMeasureEditComponentProps, UnitMeasureEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.UnitMeasures + '/' + this.props.match.params.unitMeasureCode, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.UnitMeasureClientResponseModel;
            
            console.log(response);

			let mapper = new UnitMeasureMapper();

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
            return (<UnitMeasureEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>56fba8f7e58029fd9d9cebe8eded2be0</Hash>
</Codenesium>*/