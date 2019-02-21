import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LinkLogMapper from './linkLogMapper';
import LinkLogViewModel from './linkLogViewModel';

interface Props {
    model?:LinkLogViewModel
}

   const LinkLogCreateDisplay: React.SFC<FormikProps<LinkLogViewModel>> = (props: FormikProps<LinkLogViewModel>) => {

   let status = props.status as CreateResponse<Api.LinkLogClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof LinkLogViewModel]  && props.errors[name as keyof LinkLogViewModel]) {
            response += props.errors[name as keyof LinkLogViewModel];
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
                        <label htmlFor="name" className={errorExistForField("dateEntered") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateEntered</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dateEntered" className={errorExistForField("dateEntered") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateEntered") && <small className="text-danger">{errorsForField("dateEntered")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("linkId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LinkId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="linkId" className={errorExistForField("linkId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("linkId") && <small className="text-danger">{errorsForField("linkId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("log") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Log</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="log" className={errorExistForField("log") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("log") && <small className="text-danger">{errorsForField("log")}</small>}
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


const LinkLogCreate = withFormik<Props, LinkLogViewModel>({
    mapPropsToValues: props => {
                
		let response = new LinkLogViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.dateEntered,props.model!.id,props.model!.linkId,props.model!.log);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<LinkLogViewModel> = { };

	  if(values.dateEntered == undefined) {
                errors.dateEntered = "Required"
                    }if(values.linkId == 0) {
                errors.linkId = "Required"
                    }if(values.log == '') {
                errors.log = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new LinkLogMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.LinkLogs,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.LinkLogClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'LinkLogCreate', 
  })(LinkLogCreateDisplay);

  interface LinkLogCreateComponentProps
  {
  }

  interface LinkLogCreateComponentState
  {
      model?:LinkLogViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class LinkLogCreateComponent extends React.Component<LinkLogCreateComponentProps, LinkLogCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<LinkLogCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>96788ab76bd99621daa6ae639342e314</Hash>
</Codenesium>*/