import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import VehicleMapper from '../vehicle/vehicleMapper';
import VehicleViewModel from '../vehicle/vehicleViewModel';
import {
  Spin,
  Alert,
  Select
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VehicleSelectComponentProps {
  getFieldDecorator: any;
  apiRoute:string;
  selectedValue:number;
  propertyName:string;
  required:boolean;
}

interface VehicleSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<VehicleViewModel>;
}

export class  VehicleSelectComponent extends React.Component<
VehicleSelectComponentProps,
VehicleSelectComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

  componentDidMount() {
   
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.VehicleClientResponseModel>;

          console.log(response);

          let mapper = new VehicleMapper();
          
          let devices:Array<VehicleViewModel> = [];

          response.forEach(x =>
          {
              devices.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: devices,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    

    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
    else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type='error' />;
    }
	  else if (this.state.loaded) {
      return (
        <div>
        {
          this.props.getFieldDecorator(this.props.propertyName, {
          initialValue: this.props.selectedValue,
          rules: [{ required: this.props.required, message: 'Required' }],
        })(
          <Select>
          {
            this.state.filteredRecords.map((x:VehicleViewModel) =>
            {
                return <Select.Option value={x.id}>{x.toDisplay()}</Select.Option>;
            })
          }
          </Select>
        )
      }
      </div>
    );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>a9886c04da68e4c516658458a4bf0e85</Hash>
</Codenesium>*/