import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OtherTransportMapper from './otherTransportMapper';
import OtherTransportViewModel from './otherTransportViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { HandlerSelectComponent } from '../shared/handlerSelect'
	import { PipelineStepSelectComponent } from '../shared/pipelineStepSelect'
	
interface OtherTransportCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface OtherTransportCreateComponentState {
  model?: OtherTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class OtherTransportCreateComponent extends React.Component<
  OtherTransportCreateComponentProps,
  OtherTransportCreateComponentState
> {
  state = {
    model: new OtherTransportViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as OtherTransportViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:OtherTransportViewModel) =>
  {  
    let mapper = new OtherTransportMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.OtherTransports,
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
            Api.OtherTransportClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
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
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
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
              <label htmlFor='handlerId'>handlerId</label>
              <br />             
              {getFieldDecorator('handlerId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"handlerId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='pipelineStepId'>pipelineStepId</label>
              <br />             
              {getFieldDecorator('pipelineStepId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"pipelineStepId"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedOtherTransportCreateComponent = Form.create({ name: 'OtherTransport Create' })(OtherTransportCreateComponent);

/*<Codenesium>
    <Hash>ef71563c5f49ecd2e109becb84b7a3ea</Hash>
</Codenesium>*/