import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import IncludedColumnTestMapper from './includedColumnTestMapper';
import IncludedColumnTestViewModel from './includedColumnTestViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface IncludedColumnTestCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface IncludedColumnTestCreateComponentState {
  model?: IncludedColumnTestViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class IncludedColumnTestCreateComponent extends React.Component<
  IncludedColumnTestCreateComponentProps,
  IncludedColumnTestCreateComponentState
> {
  state = {
    model: new IncludedColumnTestViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as IncludedColumnTestViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
	  else {
	      this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:IncludedColumnTestViewModel) =>
  {  
    let mapper = new IncludedColumnTestMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.IncludedColumnTests,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.IncludedColumnTestClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          if(error.response.data)
          {
			  let errorResponse = error.response.data as ActionResponse; 

			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, submitting:false, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name2'>Name2</label>
              <br />             
              {getFieldDecorator('name2', {
              rules:[{ required: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"Name2"} /> )}
              </Form.Item>

			
           <Form.Item>
            <Button type="primary" htmlType="submit" loading={this.state.submitting} >
                {(this.state.submitting ? "Submitting..." : "Submit")}
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedIncludedColumnTestCreateComponent = Form.create({ name: 'IncludedColumnTest Create' })(IncludedColumnTestCreateComponent);

/*<Codenesium>
    <Hash>5c8ac99c603154632c267becc5161d2f</Hash>
</Codenesium>*/