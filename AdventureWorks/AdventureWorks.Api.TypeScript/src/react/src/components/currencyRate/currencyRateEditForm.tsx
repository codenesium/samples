import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyRateMapper from './currencyRateMapper';
import CurrencyRateViewModel from './currencyRateViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { CurrencySelectComponent } from '../shared/currencySelect'
	interface CurrencyRateEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CurrencyRateEditComponentState {
  model?: CurrencyRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CurrencyRateEditComponent extends React.Component<
  CurrencyRateEditComponentProps,
  CurrencyRateEditComponentState
> {
  state = {
    model: new CurrencyRateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CurrencyRates +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CurrencyRateClientResponseModel;

          console.log(response);

          let mapper = new CurrencyRateMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as CurrencyRateViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CurrencyRateViewModel) =>
  {  
    let mapper = new CurrencyRateMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.CurrencyRates + '/' + this.state.model!.currencyRateID,
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
            Api.CurrencyRateClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
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
              <label htmlFor='averageRate'>AverageRate</label>
              <br />             
              {getFieldDecorator('averageRate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"AverageRate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='currencyRateDate'>CurrencyRateDate</label>
              <br />             
              {getFieldDecorator('currencyRateDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CurrencyRateDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='endOfDayRate'>EndOfDayRate</label>
              <br />             
              {getFieldDecorator('endOfDayRate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"EndOfDayRate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fromCurrencyCode'>FromCurrencyCode</label>
              <br />             
              {getFieldDecorator('fromCurrencyCode', {
              rules:[{ required: true, message: 'Required' },
{ max: 3, message: 'Exceeds max length of 3' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"FromCurrencyCode"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='toCurrencyCode'>ToCurrencyCode</label>
              <br />             
              {getFieldDecorator('toCurrencyCode', {
              rules:[{ required: true, message: 'Required' },
{ max: 3, message: 'Exceeds max length of 3' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ToCurrencyCode"} /> )}
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

export const WrappedCurrencyRateEditComponent = Form.create({ name: 'CurrencyRate Edit' })(CurrencyRateEditComponent);

/*<Codenesium>
    <Hash>c49ed038cb2337feb5e4b174e76db765</Hash>
</Codenesium>*/