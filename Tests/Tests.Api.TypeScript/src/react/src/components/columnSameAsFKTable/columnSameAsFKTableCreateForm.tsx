import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ColumnSameAsFKTableMapper from './columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from './columnSameAsFKTableViewModel';

interface Props {
    model?:ColumnSameAsFKTableViewModel
}

   const ColumnSameAsFKTableCreateDisplay: React.SFC<FormikProps<ColumnSameAsFKTableViewModel>> = (props: FormikProps<ColumnSameAsFKTableViewModel>) => {

   let status = props.status as CreateResponse<Api.ColumnSameAsFKTableClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof ColumnSameAsFKTableViewModel]  && props.errors[name as keyof ColumnSameAsFKTableViewModel]) {
            response += props.errors[name as keyof ColumnSameAsFKTableViewModel];
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
                        <label htmlFor="name" className={errorExistForField("person") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Person</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="person" className={errorExistForField("person") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("person") && <small className="text-danger">{errorsForField("person")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("personId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PersonId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="personId" className={errorExistForField("personId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("personId") && <small className="text-danger">{errorsForField("personId")}</small>}
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


const ColumnSameAsFKTableCreate = withFormik<Props, ColumnSameAsFKTableViewModel>({
    mapPropsToValues: props => {
                
		let response = new ColumnSameAsFKTableViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.person,props.model!.personId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ColumnSameAsFKTableViewModel> = { };

	  if(values.person == 0) {
                errors.person = "Required"
                    }if(values.personId == 0) {
                errors.personId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ColumnSameAsFKTableMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.ColumnSameAsFKTables,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ColumnSameAsFKTableClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ColumnSameAsFKTableCreate', 
  })(ColumnSameAsFKTableCreateDisplay);

  interface ColumnSameAsFKTableCreateComponentProps
  {
  }

  interface ColumnSameAsFKTableCreateComponentState
  {
      model?:ColumnSameAsFKTableViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ColumnSameAsFKTableCreateComponent extends React.Component<ColumnSameAsFKTableCreateComponentProps, ColumnSameAsFKTableCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ColumnSameAsFKTableCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>00dd0a4cfe5513e65110ec8920d0c889</Hash>
</Codenesium>*/